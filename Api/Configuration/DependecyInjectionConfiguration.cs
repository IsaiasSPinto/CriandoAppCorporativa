using Data.Repository;
using Manager.Implementation;
using Manager.Interfaces.Manager;
using Manager.Interfaces.Repository;

namespace Api.Configuration;

public static class DependecyInjectionConfiguration
{
    public static void AddDependecyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IClienteManager, ClienteManager>();

        services.AddScoped<IMedicoRepository, MedicoRepository>();
        services.AddScoped<IMedicoManager, MedicoManager>();

				services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
    }
}
