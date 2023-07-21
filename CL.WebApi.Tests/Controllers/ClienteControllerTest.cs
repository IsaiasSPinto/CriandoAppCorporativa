using Api.Controllers;
using Castle.Core.Logging;
using FluentAssertions;
using Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace CL.WebApi.Tests.Controllers;

public class ClienteControllerTest
{
		private readonly IClienteManager _clienteManager;
		private readonly ILogger<ClientesController> _logger;
		private readonly ClientesController _clientesController;
		public ClienteControllerTest()
		{
			_clienteManager = Substitute.For<IClienteManager>();
			_logger = Substitute.For<ILogger<ClientesController>>();
			_clientesController = new ClientesController(_clienteManager, _logger);
		}

		[Fact]
		public async Task ShouldReturnOK()
		{
				var result =  (ObjectResult)await _clientesController.Get();
				result.StatusCode.Should().Be(StatusCodes.Status200OK);
		}
}
