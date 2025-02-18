using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TesteTecFullstackAngular.Api.Domain.Entities;
using TesteTecFullstackAngular.Api.Domain.Views;

namespace TesteTecFullstackAngular.Api.Infra.ORM
{
    public class DefaultContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LivrosListaCompletaView> LivrosListaCompletaView { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
