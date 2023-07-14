using AutoMapper;
using Core.Domain;
using Core.ModelViews;
using Manager.Interfaces;

namespace Manager.Implementation;

public class ClienteManager : IClienteManager
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;
    public ClienteManager(IClienteRepository clienteRepository,IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await _clienteRepository.GetClientesAsync();
    }

    public async Task<Cliente> GetClienteAsync(int id)
    {
        return await _clienteRepository.GetClienteAsync(id);
    }

    public async Task<Cliente> InsertClienteAsync(NovoCliente novoCliente)
    {
        var cliente = _mapper.Map<Cliente>(novoCliente);
        return await _clienteRepository.InsertClienteAsync(cliente);
    }

    public async Task<Cliente> UpdateClienteAsync(AlteraCliente clienteAlterado)
    {
        var cliente = _mapper.Map<Cliente>(clienteAlterado);
        return await _clienteRepository.UpdateClienteAsync(cliente);
    }

    public async Task DeleteClienteAsync(int id)
    {
        await _clienteRepository.DeleteClienteAsync(id);
    }
}
