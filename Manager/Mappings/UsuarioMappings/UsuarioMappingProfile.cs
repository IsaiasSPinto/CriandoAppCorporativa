using AutoMapper;
using Core.Domain;
using Core.ModelViews.Usuario;

namespace Manager.Mappings.UsuarioMappings;
public class UsuarioMappingProfile : Profile
{
		public UsuarioMappingProfile()
		{
				CreateMap<Usuario, UsuarioView>().ReverseMap();
		}
}
