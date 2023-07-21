using Core.Domain;
using Core.ModelViews.Cliente;

namespace Manager.Interfaces.Manager;

public interface IClienteManager
{
    Task<IEnumerable<ClienteView>> GetClientesAsync();
    Task<ClienteView> GetClienteAsync(int id);
    Task<ClienteView> InsertClienteAsync(NovoCliente novoCliente);
    Task<ClienteView> UpdateClienteAsync(AlteraCliente clienteAlterado);
    Task DeleteClienteAsync(int id);
}
