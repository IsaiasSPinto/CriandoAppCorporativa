using AutoMapper;
using Core.ModelViews.Cliente;
using Core.Domain;

namespace Manager.Mappings.ClienteMappings;

public class AlteraClienteMappingProfile : Profile
{
    public AlteraClienteMappingProfile()
    {
        CreateMap<AlteraCliente, Cliente>()
            .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
    }
}
