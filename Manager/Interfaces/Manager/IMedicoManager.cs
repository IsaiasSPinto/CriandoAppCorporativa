using Core.Domain;
using Core.ModelViews.Medico;

namespace Manager.Interfaces.Manager;

public interface IMedicoManager
{
    Task<IEnumerable<MedicoView>> GetMedicosAsync();
    Task<MedicoView> GetMedicoAsync(int id);
    Task<MedicoView> InsertMedicoAsync(NovoMedico novoCliente);
    Task<MedicoView> UpdateMedicoAsync(AlteraMedico clienteAlterado);
    Task DeleteMedicoAsync(int id);
}
