using System.Text.Json.Serialization;
using Api.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;

//IConfigurationRoot configuration = GetConfiguration();
//ConfiguraLog(configuration);

try
{
		//Log.Information("Iniciando APP");

		var builder = WebApplication.CreateBuilder(args);

		//builder.Host.UseSerilog(Log.Logger);
		var services = builder.Services;

		services.AddControllers()
				.AddNewtonsoftJson(x =>
				{
						x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
						x.SerializerSettings.Converters.Add(new StringEnumConverter());
				})
				.AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

    services.AddDatabaseConfiguration(builder.Configuration);

    services.AddDependecyInjectionConfiguration();

    services.AddAutoMapperConfiguration();

    services.AddFluentValidationConfiguration();

    services.AddSwaggerConfiguration();

    var app = builder.Build();

    app.UseExceptionHandler("/error");

    if(app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseDatabaseConfiguration();

    app.UseSwaggerConfiguration();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
		//Log.Fatal(ex, "Ocorreu um erro");
}
finally
{
		//Log.Information("Desligando...");
		//Log.CloseAndFlush();
}

static IConfigurationRoot GetConfiguration()
{
    var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{ambiente}.json",optional: true)
        .Build();
    return configuration;
}

static void ConfiguraLog(IConfigurationRoot configuration)
{
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
}
