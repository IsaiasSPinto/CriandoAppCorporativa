using System.Reflection;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

namespace Api.Configuration;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Consultorio Legal",
                    Version = "v1",
                    Description = "Api da aplicação consultório legal.",
                    Contact = new OpenApiContact
                    {
                        Name = "Isais Pinto",
                        Email = "isaiascxs10@gmail.com",
                        Url = new Uri("https://github.com/IsaiasSPinto"),
                    },
                    License = new OpenApiLicense { 
                        Name = "OSD",
                        Url = new Uri("https://opensource.org/osd")
                    },
                    TermsOfService = new Uri("https://opensource.org/osd")
                });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
            c.IncludeXmlComments(xmlPath);
            xmlPath = Path.Combine(AppContext.BaseDirectory, "Core.xml");
            c.IncludeXmlComments(xmlPath);
        });

        services.AddFluentValidationRulesToSwagger();
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
