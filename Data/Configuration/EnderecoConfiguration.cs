using Core.Domain;
using Core.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.ClienteId);
				builder.Property(c => c.Estado).HasConversion(v => v.ToString(), v => (Estado)Enum.Parse(typeof(Estado), v));
		}
}
