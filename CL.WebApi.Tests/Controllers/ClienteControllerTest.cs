using Api.Controllers;
using CL.FakeData.ClienteData;
using Core.ModelViews.Cliente;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CL.WebApi.Tests.Controllers;

public class ClienteControllerTest
{
		private readonly IClienteManager _clienteManager;
		private readonly ILogger<ClientesController> _logger;
		private readonly ClientesController _clientesController;
		private readonly List<ClienteView> _clientFakeList;
		private readonly ClienteView _clientFake;
		private readonly NovoCliente _novoClienteFake;

		public ClienteControllerTest()
		{
				_clienteManager = Substitute.For<IClienteManager>();
				_logger = Substitute.For<ILogger<ClientesController>>();
				_clientesController = new ClientesController(_clienteManager, _logger);
				_clientFakeList = new ClienteViewFaker().Generate(10);
				_clientFake = new ClienteViewFaker().Generate();
				_novoClienteFake = new NovoClienteFaker().Generate();
		}

		[Fact]
		public async Task GetClientesShouldReturnOK()
		{
				var clonedValues = _clientFakeList.Select(x => x.CloneClienteView()).ToList();
				_clienteManager.GetClientesAsync().Returns(_clientFakeList);

				var result = (ObjectResult)await _clientesController.Get();

				await _clienteManager.Received().GetClientesAsync();
				result.StatusCode.Should().Be(StatusCodes.Status200OK);
				result.Value.Should().BeEquivalentTo(clonedValues);
		}

		[Fact]
		public async Task GetClientesShouldReturnNotFound()
		{
				_clienteManager.GetClientesAsync().Returns(new List<ClienteView>());

				var resultado = (StatusCodeResult)await _clientesController.Get();

				await _clienteManager.Received().GetClientesAsync();
				resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
		}

		[Fact]
		public async Task GetClienteShouldReturnOK()
		{
				_clienteManager.GetClienteAsync(Arg.Any<int>()).Returns(_clientFake.CloneClienteView());

				var result = (ObjectResult)await _clientesController.Get(_clientFake.Id);

				await _clienteManager.Received().GetClienteAsync(_clientFake.Id);
				result.StatusCode.Should().Be(StatusCodes.Status200OK);
				result.Value.Should().BeEquivalentTo(_clientFake);
		}

		[Fact]
		public async Task GetClienteshouldReturnNotFound()
		{
				_clienteManager.GetClienteAsync(Arg.Any<int>()).ReturnsNull();

				var resultado = (StatusCodeResult)await _clientesController.Get(1);

				await _clienteManager.Received().GetClienteAsync(Arg.Any<int>());
				resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
		}

		[Fact]
		public async Task ShouldCreateNovoCliente()
		{
				_clienteManager.InsertClienteAsync(Arg.Any<NovoCliente>()).Returns(_clientFake.CloneClienteView());

				var resultado = (ObjectResult)await _clientesController.Post(_novoClienteFake);

				await _clienteManager.Received().InsertClienteAsync(Arg.Any<NovoCliente>());
				resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
				resultado.Value.Should().BeEquivalentTo(_clientFake);
		}

		[Fact]
		public async Task ShouldUpdateCliente()
		{
				_clienteManager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).Returns(_clientFake.CloneClienteView());

				var resultado = (ObjectResult)await _clientesController.Put(new AlteraCliente());

				await _clienteManager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
				resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
				resultado.Value.Should().BeEquivalentTo(_clientFake);
		}

		[Fact]
		public async Task ShouldDeleteCliente()
		{
				await _clienteManager.DeleteClienteAsync(Arg.Any<int>());

				var resultado = (StatusCodeResult)await _clientesController.Delete(1);

				await _clienteManager.Received().DeleteClienteAsync(Arg.Any<int>());
				resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);
		}


}
