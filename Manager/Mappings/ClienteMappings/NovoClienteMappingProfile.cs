using AutoMapper;
using Core.Domain;
using Core.ModelViews.Cliente;
using Core.ModelViews.Endereco;
using Core.ModelViews.Telefone;

namespace Manager.Mappings.ClienteMappings;

public class NovoClienteMappingProfile : Profile
{
    public NovoClienteMappingProfile()
    {
        CreateMap<NovoCliente, Cliente>()
            .ForMember(d => d.Criacao, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

				CreateMap<Cliente, ClienteView>();
				CreateMap<ClienteView, Cliente>();

				CreateMap<NovoEndereco, Endereco>();
        CreateMap<NovoTelefone, Telefone>();
				CreateMap<Telefone, TelefoneView>();

		}
}
