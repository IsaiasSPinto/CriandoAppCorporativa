using Core.Domain;
using Core.ModelViews;

namespace Manager.Interfaces.Manager;

public interface IMedicoManager
{
    Task<IEnumerable<Medico>> GetMedicosAsync();
    Task<Medico> GetMedicoAsync(int id);
    Task<Medico> InsertMedicoAsync(NovoMedico novoCliente);
    Task<Medico> UpdateMedicoAsync(AlteraMedico clienteAlterado);
    Task DeleteMedicoAsync(int id);
}
