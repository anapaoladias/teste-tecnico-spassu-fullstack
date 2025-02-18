using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTecFullstackAngular.Api.Domain.Views;

namespace TesteTecFullstackAngular.Api.Infra.ORM.Mapping
{
    public class ViewsConfiguration : IEntityTypeConfiguration<LivrosListaCompletaView>
    {
        public void Configure(EntityTypeBuilder<LivrosListaCompletaView> builder)
        {
            builder.HasNoKey();
            builder.ToView("vwLivrosCompleta");
        }
    }
}
