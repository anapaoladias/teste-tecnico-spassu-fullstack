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

    public class LivroAutorConfiguration : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            builder.HasKey(la => new { la.Livro_CodI, la.Autor_CodAu });

            builder.HasOne(la => la.Livro)
                .WithMany(l => l.LivroAutores)
                .HasForeignKey(la => la.Livro_CodI);

            builder.HasOne(la => la.Autor)
                .WithMany(a => a.LivroAutores)
                .HasForeignKey(la => la.Autor_CodAu);
        }
    }

    public class LivroAssuntoConfiguration : IEntityTypeConfiguration<LivroAssunto>
    {
        public void Configure(EntityTypeBuilder<LivroAssunto> builder)
        {
            builder.HasKey(la => new { la.Livro_CodI, la.Assunto_codAs });

            builder.HasOne(la => la.Livro)
                .WithMany(l => l.LivroAssuntos)
                .HasForeignKey(la => la.Livro_CodI);

            builder.HasOne(la => la.Assunto)
                .WithMany(a => a.LivroAssuntos)
                .HasForeignKey(la => la.Assunto_codAs);
        }
    }
}
