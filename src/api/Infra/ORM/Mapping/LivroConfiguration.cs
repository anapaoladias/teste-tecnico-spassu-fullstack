using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Domain.Entities;

namespace TesteTecFullstackAngular.Api.Infra.ORM.Mapping
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Codl);

            builder.Property(l => l.Codl)
                .HasColumnType("INTEGER")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(l => l.Titulo)
                .HasColumnType("VARCHAR(40)")
                .IsRequired();

            builder.Property(l => l.Editora)
                .HasColumnType("VARCHAR(40)")
                .IsRequired();

            builder.Property(l => l.Edicao)
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(l => l.AnoPublicacao)
                .HasColumnType("VARCHAR(4)")
                .IsRequired();
        }
    }
}
