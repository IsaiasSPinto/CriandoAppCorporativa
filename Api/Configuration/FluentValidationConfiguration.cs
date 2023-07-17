﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Manager.Validator;
using System.Globalization;

namespace Api.Configuration;

public static class FluentValidationConfiguration
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<NovoClienteValidator>();
        services.AddValidatorsFromAssemblyContaining<AlteraClienteValidator>();
        services.AddValidatorsFromAssemblyContaining<NovoEnderecoValidator>();


        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

    }
}
