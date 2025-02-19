using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Application.ViewModels;
using TesteTecFullstackAngular.Api.Domain.Entities;
using TesteTecFullstackAngular.Api.Domain.Interfaces;
using TesteTecFullstackAngular.Api.Domain.Views;
using TesteTecFullstackAngular.Api.Infra.ORM;

namespace TesteTecFullstackAngular.Api.Application.Services
{
    public class RelatoriosService : IRelatoriosService
    {
        private readonly DefaultContext _context;

        public RelatoriosService(DefaultContext context)
        {
            _context = context;
        }

        public async Task<List<LivrosListaCompletaView>> ObterLivrosCompleta(CancellationToken cancellationToken = default)
        {
            return await _context.LivrosListaCompletaView.ToListAsync(cancellationToken);
        }

        public async Task<List<LivrosAgrupadoAutorResponse>> ObterLivrosAgrupadaPorAutor(CancellationToken cancellationToken = default)
        {
            var livros = await _context.LivrosListaCompletaView.ToListAsync(cancellationToken);

            var livrosAgrupadosPorAutor = livros
                // agrupa por Autor
                .GroupBy(livro => livro.CodigoAutor)
                .Select(grupo => new LivrosAgrupadoAutorResponse
                {
                    CodigoAutor = grupo.Key,
                    Autor = grupo.First().Autor,
                    Livros = grupo
                    // Agrupa por Livros, pois podem ter mais de um Assunto
                    .GroupBy(livro => livro.CodigoLivro)
                    .Select(livroGrupo => new LivrosAgrupadoAutorItensResponse
                    {
                        CodigoLivro = livroGrupo.Key,
                        Titulo = livroGrupo.First().Titulo,
                        Editora = livroGrupo.First().Editora,
                        Edicao = livroGrupo.First().Edicao,
                        AnoPublicacao = livroGrupo.First().AnoPublicacao,
                        Valor = livroGrupo.First().Valor,
                        // Formata em uma linha só os assuntos, separados por virgula
                        Assuntos = string.Join(", ", livroGrupo.Select(l => l.Assunto).Distinct())
                    }).ToList()
                }).ToList();

            return livrosAgrupadosPorAutor;
        }
    }
}
