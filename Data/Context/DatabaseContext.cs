using Core.Domain;
using Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) 
    { 
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Telefone> Telefones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
    }
}
