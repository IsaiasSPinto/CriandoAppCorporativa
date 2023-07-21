using Core.Domain;
using Core.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {     
        builder.Property(c => c.Nome).HasMaxLength(200).IsRequired();
				builder.Property(c => c.Sexo).HasConversion(v => v.ToString(), v => (Sexo)Enum.Parse(typeof(Sexo), v));
    }
}
