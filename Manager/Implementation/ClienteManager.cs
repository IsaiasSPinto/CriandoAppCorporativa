using System.Collections.Generic;
using AutoMapper;
using Core.Domain;
using Core.ModelViews.Cliente;
using Core.ModelViews.Medico;
using Manager.Interfaces.Manager;
using Manager.Interfaces.Repository;

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

    public async Task<IEnumerable<ClienteView>> GetClientesAsync()
    {
				return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteView>>(await _clienteRepository.GetClientesAsync());
    }

    public async Task<ClienteView> GetClienteAsync(int id)
    {
        return _mapper.Map<ClienteView>(await _clienteRepository.GetClienteAsync(id));
    }

    public async Task<ClienteView> InsertClienteAsync(NovoCliente novoCliente)
    {
        var cliente = _mapper.Map<Cliente>(novoCliente);
        return _mapper.Map<ClienteView>(await _clienteRepository.InsertClienteAsync(cliente));
    }

    public async Task<ClienteView> UpdateClienteAsync(AlteraCliente clienteAlterado)
    {
        var cliente = _mapper.Map<Cliente>(clienteAlterado);
        return _mapper.Map<ClienteView>(await _clienteRepository.UpdateClienteAsync(cliente));
    }

    public async Task DeleteClienteAsync(int id)
    {
        await _clienteRepository.DeleteClienteAsync(id);
    }
}
