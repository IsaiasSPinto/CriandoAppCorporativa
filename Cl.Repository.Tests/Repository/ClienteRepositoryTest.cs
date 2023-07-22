using CL.FakeData.ClienteData;
using Core.Domain;
using Data.Context;
using Data.Repository;
using Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using CL.FakeData.TelefoneData;

namespace Cl.Repository.Tests.Repository;

public class ClienteRepositoryTest : IDisposable
{
    private readonly IClienteRepository _clienteRepository;
    private readonly DatabaseContext _context;
    private readonly Cliente _cliente;
    private ClienteFaker _clienteFaker;
    public ClienteRepositoryTest()
    {
        var optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionBuilder.UseInMemoryDatabase("DbTest");
        _context = new DatabaseContext(optionBuilder.Options);
        _clienteRepository = new ClienteRepository(_context);
        _cliente = new ClienteFaker().Generate();
        _clienteFaker = new ClienteFaker();
    }

    [Fact]
    public async Task ShouldGetClientes()
    {
        var resgistros = await InsertData(100);

        var retorno = await _clienteRepository.GetClientesAsync();

        retorno.Should().HaveCount(resgistros.Count);
        retorno.First().Endereco.Should().NotBeNull();
        retorno.First().Telefones.Should().NotBeNull();
    }

    [Fact]
    public async Task ShouldGetClientesEmpty()
    {
        var retorno = await _clienteRepository.GetClientesAsync();

        retorno.Should().HaveCount(0);
    }

    [Fact]
    public async Task ShouldGetCliente()
    {
        var resgistros = await InsertData(10);

        var retorno = await _clienteRepository.GetClienteAsync(resgistros.First().Id);

        retorno.Should().BeEquivalentTo(resgistros.First());
    }

    [Fact]
    public async Task ShouldntGetCliente()
    {
        var retorno = await _clienteRepository.GetClienteAsync(1);

        retorno.Should().BeNull();
    }


    [Fact]
    public async Task ShouldInsertCliente()
    {

        var retorno = await _clienteRepository.InsertClienteAsync(_cliente);

        retorno.Should().BeEquivalentTo(_cliente);
    }

    [Fact]
    public async Task ShouldUpdateCliente()
    {
        var registros = await InsertData(10);

        var clienteAlterado = _clienteFaker.Generate();
        clienteAlterado.Id = registros.First().Id;

        var retorno = await _clienteRepository.UpdateClienteAsync(clienteAlterado);

        retorno.Should().BeEquivalentTo(clienteAlterado);
    }

    [Fact]
    public async Task ShouldUpdateClienteAdicionaTelefones()
    {
        var registros = await InsertData(10);

        var clienteAlterado = registros.First();
        clienteAlterado.Telefones.Add(new TelefoneFaker(clienteAlterado.Id).Generate());

        var retorno = await _clienteRepository.UpdateClienteAsync(clienteAlterado);
        retorno.Should().BeEquivalentTo(clienteAlterado);
    }

    [Fact]
    public async Task ShouldUpdateClienteRemoveTelefone()
    {
        var registros = await InsertData(10);

        var clienteAlterado = registros.First();
        clienteAlterado.Telefones.Remove(clienteAlterado.Telefones.First());

        var retorno = await _clienteRepository.UpdateClienteAsync(clienteAlterado);
        retorno.Should().BeEquivalentTo(clienteAlterado);
    }

    [Fact]
    public async Task ShouldUpdateClienteRemoveTelefones()
    {
        var registros = await InsertData(10);

        var clienteAlterado = registros.First();
        clienteAlterado.Telefones.Clear();

        var retorno = await _clienteRepository.UpdateClienteAsync(clienteAlterado);
        retorno.Should().BeEquivalentTo(clienteAlterado);
    }

    [Fact]
    public async Task ShouldNotFoundUpdateCliente()
    {
        var retorno = await _clienteRepository.UpdateClienteAsync(_cliente);
        retorno.Should().BeNull();
    }

    [Fact]
    public async Task ShouldDeleteCliente()
    {
        var registros = await InsertData(10);

        await _clienteRepository.DeleteClienteAsync(registros.First().Id);

        var retorno = await _clienteRepository.GetClienteAsync(registros.First().Id);

        retorno.Should().BeNull();
    }


    private async Task<List<Cliente>> InsertData(int count)
    {
        var clientes = _clienteFaker.Generate(count).Select(x => { x.Id = 0; return x; }).ToList();

        _context.AddRange(clientes);
        await _context.SaveChangesAsync();

        return clientes;
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
    }
}
