using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Domain.Entities;

namespace TesteTecFullstackAngular.Api.Infra.ORM.Mapping
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(a => a.CodAu);

            builder.Property(l => l.CodAu)
                .HasColumnType("INTEGER")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.Nome)
                .HasColumnType("VARCHAR(40)")
                .IsRequired();
        }
    }
}
