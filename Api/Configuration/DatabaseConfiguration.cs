using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Configuration;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("Conn")));
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app) 
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();        
        using var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();
        context.Database.Migrate();        
    }
}
