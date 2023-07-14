using Core.Domain;

namespace Manager.Interfaces;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> GetClienteAsync(int id);
    Task<Cliente> InsertClienteAsync(Cliente cliente);
    Task<Cliente> UpdateClienteAsync(Cliente cliente);
    Task DeleteClienteAsync(int id);
}

