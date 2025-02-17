using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Domain.Entities;

namespace TesteTecFullstackAngular.Api.Infra.ORM.Mapping
{
    public class AssuntoConfiguration : IEntityTypeConfiguration<Assunto>
    {
        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder.HasKey(a => a.CodAs);

            builder.Property(l => l.CodAs)
                .HasColumnType("INTEGER")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.Descricao)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();
        }
    }
}
