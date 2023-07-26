using Core.Domain;
using Core.ModelViews.Usuario;
using Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
		private readonly IUsuarioManager _usuarioManager;

		public UsuariosController(IUsuarioManager usuarioManager)
		{
				_usuarioManager = usuarioManager;
		}


		[HttpPost]
		[Route("login")]
		[ProducesResponseType(typeof(UsuarioLogado), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> Login(Usuario usuario)
		{
				var usuarioLogado = await _usuarioManager.ValidaUsuarioAsync(usuario);
				if (usuarioLogado != null)
				{
						return Ok(usuarioLogado);
				}

				return Unauthorized();
		}


		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
				string login = User.Identity.Name;
				var usuario = await _usuarioManager.GetUsuarioAsync(login);

				return Ok(usuario);
		}

		[HttpPost]
		public async Task<IActionResult> Post(NovoUsuario novoUsuario)
		{
				var usuarioInserido = await _usuarioManager.InsertUsuarioAsync(novoUsuario);

				return CreatedAtAction(nameof(Get), new { login = novoUsuario.Login }, usuarioInserido);
		}
}
