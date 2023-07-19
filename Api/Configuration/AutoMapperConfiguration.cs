using Manager.Mappings.ClienteMappings;
using Manager.Mappings.MedicoMappings;

namespace Api.Configuration;

public static class AutoMapperConfiguration
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AlteraClienteMappingProfile));
        services.AddAutoMapper(typeof(NovoMedicoMappingProfile));

    }
}
