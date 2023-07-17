using Core.Domain;
using Core.ModelViews;
using Manager.Interfaces.Manager;
using Manager.Interfaces.Repository;

namespace Manager.Implementation;
public class MedicoManager : IMedicoManager
{
    private readonly IMedicoRepository _medicoRepository;

    public MedicoManager(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository; 
    }

    public async Task<IEnumerable<Medico>> GetMedicosAsync()
    {
        return await _medicoRepository.GetMedicosAsync();
    }

    public async Task<Medico> GetMedicoAsync(int id)
    {
        return await _medicoRepository.GetMedicoAsync(id);
    }


    public async Task<Medico> InsertMedicoAsync(NovoCliente novoCliente)
    {
        throw new NotImplementedException();
    }

    public async Task<Medico> UpdateMedicoAsync(AlteraCliente clienteAlterado)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteMedicoAsync(int id)
    {
        throw new NotImplementedException();
    }
}
