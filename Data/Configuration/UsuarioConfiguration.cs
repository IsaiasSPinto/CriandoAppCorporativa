using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
				builder.HasKey(x => x.Login);
		}
}
