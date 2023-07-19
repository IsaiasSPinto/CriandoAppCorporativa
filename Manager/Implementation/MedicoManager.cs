using AutoMapper;
using Core.Domain;
using Core.ModelViews.Medico;
using Manager.Interfaces.Manager;
using Manager.Interfaces.Repository;

namespace Manager.Implementation;
public class MedicoManager : IMedicoManager
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly IMapper _mapper;

    public MedicoManager(IMedicoRepository medicoRepository, IMapper mapper)
    {
        _medicoRepository = medicoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicoView>> GetMedicosAsync()
    {
        return _mapper.Map<IEnumerable<Medico>, IEnumerable<MedicoView>>(await _medicoRepository.GetMedicosAsync());
    }

    public async Task<MedicoView> GetMedicoAsync(int id)
    {
        return _mapper.Map<MedicoView>(await _medicoRepository.GetMedicoAsync(id));
    }


    public async Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico)
    {
        var medico = _mapper.Map<NovoMedico, Medico>(novoMedico);
        return _mapper.Map<MedicoView>(await _medicoRepository.InsertMedicoAsync(medico));
    }

    public async Task<MedicoView> UpdateMedicoAsync(AlteraMedico medicoAlterado)
    {
        var medico = _mapper.Map<AlteraMedico, Medico>(medicoAlterado);
        return _mapper.Map<MedicoView>(await _medicoRepository.UpdateMedicoAsync(medico));
    }
    public async Task DeleteMedicoAsync(int id)
    {
        await _medicoRepository.DeleteMedicoAsync(id);
    }
}
