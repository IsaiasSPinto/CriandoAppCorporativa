using Core.Domain;
using Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Http;
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

		public async Task<IActionResult> ValidaUsuario([FromBody] Usuario usuario)
		{
				var valido = await _usuarioManager.ValidaSenhaAsync(usuario);
				if(valido)
				{
						return Ok(valido);
				}
				return Unauthorized();
		}


		[HttpGet]
		public async Task<IActionResult> Get(string login)
		{
				return Ok("ad");
		}

		[HttpPost]
		public async Task<IActionResult> Post(Usuario usuario)
		{
				var usuarioInserido = await _usuarioManager.InsertUsuarioAsync(usuario);
				return CreatedAtAction(nameof(Get), new { login = usuario.Login }, usuarioInserido);
		}
}
