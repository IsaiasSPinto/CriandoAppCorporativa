using Core.Domain;
using Data.Context;
using Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;
public class UsuarioRepository : IUsuarioRepository
{
		private readonly DatabaseContext _context;
		public UsuarioRepository(DatabaseContext context)
		{
				_context = context;
		}

		public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
		{
				return await _context.Usuarios.AsNoTracking().ToListAsync();
		}

		public async Task<Usuario> GetUsuarioAsync(string login)
		{
				return await _context.Usuarios.FindAsync(login);
		}

		public async Task<Usuario> InsertUsuarioAsync(Usuario usuario)
		{
				_context.Add(usuario);
				await _context.SaveChangesAsync();
				return usuario;
		}

		public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
		{
				var usuarioConsultado = await _context.Usuarios.FindAsync(usuario.Login);
				if (usuarioConsultado == null)
				{
						return null;
				}

				_context.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
				await _context.SaveChangesAsync();
				return usuario;
		}

		public async Task DeleteUsuarioAsync(string login)
		{
				var usuarioConsultado = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == login);
				if (usuarioConsultado == null)
				{
						return;
				}

				_context.Remove(usuarioConsultado);
				await _context.SaveChangesAsync();
		}
}
