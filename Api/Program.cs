using System.Text.Json.Serialization;
using Api.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers()
		.AddNewtonsoftJson(x =>
		{
				x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				x.SerializerSettings.Converters.Add(new StringEnumConverter());
		})
		.AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

services.AddJWTConfiguration(builder.Configuration);

services.AddDatabaseConfiguration(builder.Configuration);

services.AddDependecyInjectionConfiguration();

services.AddAutoMapperConfiguration();

services.AddFluentValidationConfiguration();

services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
		app.UseDeveloperExceptionPage();
}

app.UseDatabaseConfiguration();

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseJWTConfiguration();

app.MapControllers();

app.Run();


