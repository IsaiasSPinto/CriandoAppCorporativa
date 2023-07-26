using Api.Controllers;
using Core.ModelViews.Usuario;

namespace CL.WebApi.Tests.Controllers;

public class UsuarioControllerTest
{

		private readonly UsuariosController _controller;
		private readonly IUsuarioManager _manager;
		private readonly UsuarioView _usuarioView;
		public UsuarioControllerTest()
		{
				_manager = Substitute.For<IUsuarioManager>(); 
				_controller = new UsuariosController(_manager);
				_usuarioView = new 
		}

}
