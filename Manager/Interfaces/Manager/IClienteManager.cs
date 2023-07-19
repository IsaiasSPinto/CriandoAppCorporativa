using Core.Domain;
using Core.ModelViews.Cliente;

namespace Manager.Interfaces.Manager;

public interface IClienteManager
{
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> GetClienteAsync(int id);
    Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);
    Task<Cliente> UpdateClienteAsync(AlteraCliente clienteAlterado);
    Task DeleteClienteAsync(int id);
}
