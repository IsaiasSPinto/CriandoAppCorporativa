using Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

services.AddDatabaseConfiguration(builder.Configuration);

services.AddDependecyInjectionConfiguration();

services.AddAutoMapperConfiguration();

services.AddFluentValidationConfiguration();

services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseDatabaseConfiguration();

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
