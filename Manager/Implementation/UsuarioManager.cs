using AutoMapper;
using Core.Domain;
using Core.ModelViews.Usuario;
using Manager.Interfaces.Manager;
using Manager.Interfaces.Repository;
using Manager.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Manager.Implementation;
public class UsuarioManager : IUsuarioManager
{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly IMapper _mapper;
		private readonly IJWTService _jwtService;
		public UsuarioManager(IUsuarioRepository usuarioRepository, IMapper mapper,IJWTService jwt)
		{
				_usuarioRepository = usuarioRepository;
				_mapper = mapper;
				_jwtService = jwt;
		}
		public async Task<UsuarioView> GetUsuarioAsync(string login)
		{
				return _mapper.Map<UsuarioView>(await _usuarioRepository.GetUsuarioAsync(login));
		}

		public async Task<IEnumerable<UsuarioView>> GetUsuariosAsync()
		{
				return _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioView>>(await _usuarioRepository.GetUsuariosAsync());
		}

		public async Task<UsuarioView> InsertUsuarioAsync(NovoUsuario novoUsuario)
		{
				var usuario = _mapper.Map<Usuario>(novoUsuario);
				HashSenha(usuario);
				return _mapper.Map<UsuarioView>(await _usuarioRepository.InsertUsuarioAsync(usuario));
		}

		private static void HashSenha(Usuario usuario)
		{
				var passwordHasher = new PasswordHasher<Usuario>();
				usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
		}

		public async Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario)
		{
				HashSenha(usuario);

				return _mapper.Map<UsuarioView>(await _usuarioRepository.UpdateUsuarioAsync(usuario));
		}

		public async Task<UsuarioLogado> ValidaUsuarioAsync(Usuario usuario)
		{
				var usuarioConsultado = await _usuarioRepository.GetUsuarioAsync(usuario.Login);

				if (usuarioConsultado == null)
				{
						return null;
				}

				if(await ValidaHashAsync(usuario, usuarioConsultado.Senha))
				{
						var usuarioView = _mapper.Map<UsuarioLogado>(usuarioConsultado);
						usuarioView.Token = _jwtService.GerarToken(usuarioConsultado);
						return usuarioView;
				}

				return null;
		}

		private async Task<bool> ValidaHashAsync(Usuario usuario, string hash)
		{
				var passwordHasher = new PasswordHasher<Usuario>();
				var status = passwordHasher.VerifyHashedPassword(usuario, hash, usuario.Senha);

				switch (status)
				{
						case PasswordVerificationResult.Failed:
								return false;
						case PasswordVerificationResult.Success:
								return true;
						case PasswordVerificationResult.SuccessRehashNeeded:
								await UpdateUsuarioAsync(usuario);
								return true;
						default:
								throw new InvalidOperationException();
				}
		}
}
