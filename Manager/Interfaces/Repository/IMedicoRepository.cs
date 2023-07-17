using Core.Domain;

namespace Manager.Interfaces.Repository;

public interface IMedicoRepository
{
    Task<IEnumerable<Medico>> GetMedicosAsync();
    Task<Medico> GetMedicoAsync(int id);
    Task<Medico> InsertMedicoAsync(Medico medico);
    Task<Medico> UpdateMedicoAsync(Medico medico);
    Task DeleteMedicoAsync(int id);
}
