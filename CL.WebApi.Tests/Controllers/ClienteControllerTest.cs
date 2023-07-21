using Api.Controllers;
using CL.FakeData.ClienteData;
using Core.ModelViews.Cliente;
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
		private readonly List<ClienteView> _clientFakeList;
		private readonly ClienteView _clientFake;

		public ClienteControllerTest()
		{
			_clienteManager = Substitute.For<IClienteManager>();
			_logger = Substitute.For<ILogger<ClientesController>>();
			_clientesController = new ClientesController(_clienteManager, _logger);
			_clientFakeList = new ClienteViewFaker().Generate(10);
			_clientFake = new ClienteViewFaker().Generate();
		}

		[Fact]
		public async Task ShouldReturnOK()
		{
				var clonedValues = _clientFakeList.Select(x => x.CloneClienteView()).ToList();
				_clienteManager.GetClientesAsync().Returns(_clientFakeList);

				var result =  (ObjectResult)await _clientesController.Get();
				result.StatusCode.Should().Be(StatusCodes.Status200OK);
				result.Value.Should().BeEquivalentTo(clonedValues);
		}
}
