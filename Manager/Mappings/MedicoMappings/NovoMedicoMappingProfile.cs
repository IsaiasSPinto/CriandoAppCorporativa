using AutoMapper;
using Core.Domain;
using Core.ModelViews.Especialidade;
using Core.ModelViews.Medico;

namespace Manager.Mappings.MedicoMappings;

public class NovoMedicoMappingProfile : Profile
{
    public NovoMedicoMappingProfile()
    {
        CreateMap<NovoMedico, Medico>().ReverseMap();            
        CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
        CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
        CreateMap<AlteraMedico, Medico>().ReverseMap();
    }
}
