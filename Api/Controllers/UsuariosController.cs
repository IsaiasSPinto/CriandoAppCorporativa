using Core.Domain;
using Core.ModelViews.Medico;
using Manager.Interfaces.Manager;
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
		[Route("ValidaUsuario")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> ValidaUsuario(Usuario usuario)
		{
				bool valido = await _usuarioManager.ValidaSenhaAsync(usuario);
				if (valido)
				{
						return Ok(valido);
				}

				return Unauthorized();
		}


		[HttpGet("{usuario}")]
		public async Task<IActionResult> Get(string login)
		{
				var usuario = await _usuarioManager.GetUsuarioAsync(login);

				return Ok(usuario);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Usuario usuario)
		{
				var usuarioInserido = await _usuarioManager.InsertUsuarioAsync(usuario);

				return CreatedAtAction(nameof(Get), new { login = usuario.Login }, usuarioInserido);
		}
}
