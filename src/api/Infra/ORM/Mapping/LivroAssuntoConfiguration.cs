using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Domain.Entities;

namespace TesteTecFullstackAngular.Api.Infra.ORM.Mapping
{
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
