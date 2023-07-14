using System.Globalization;
using Data.Context;
using Data.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Manager.Implementation;
using Manager.Interfaces;
using Manager.Mappings;
using Manager.Validator;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region FluentValidation

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<NovoClienteValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AlteraClienteValidator>();

ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

#endregion

#region MyInterfaces

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteManager, ClienteManager>();

#endregion

#region DatabaseConfig
var connectionString = builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(typeof(NovoClienteMappingProfile));
builder.Services.AddAutoMapper(typeof(AlteraClienteMappingProfile));


#endregion

#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Consultorio Legal", Version = "v1" });
});

#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider
            .GetRequiredService<DatabaseContext>();

        dbContext.Database.Migrate();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
