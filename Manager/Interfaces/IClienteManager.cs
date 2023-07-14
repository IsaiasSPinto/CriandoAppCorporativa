using Core.Domain;
using Core.ModelViews;

namespace Manager.Interfaces;

public interface IClienteManager
{
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> GetClienteAsync(int id);
    Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);
    Task<Cliente> UpdateClienteAsync(AlteraCliente clienteAlterado);
    Task DeleteClienteAsync(int id);
}
