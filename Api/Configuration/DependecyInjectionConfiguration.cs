﻿using Data.Repository;
using Manager.Implementation;
using Manager.Interfaces;

namespace Api.Configuration;

public static class DependecyInjectionConfiguration
{
    public static void AddDependecyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IClienteManager, ClienteManager>();
    }
}