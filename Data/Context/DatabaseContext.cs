using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
