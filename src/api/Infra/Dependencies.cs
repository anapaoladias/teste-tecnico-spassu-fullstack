using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Application.Services;
using TesteTecFullstackAngular.Api.Domain.Interfaces;
using TesteTecFullstackAngular.Api.Infra.ORM;

namespace TesteTecFullstackAngular.Api.Infra
{
    public static class Dependencies
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            // database
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());

            // services
            builder.Services.AddTransient<IBibliotecaService, BibliotecaService>();
            builder.Services.AddTransient<IRelatoriosService, RelatoriosService>();
        }
    }
}
