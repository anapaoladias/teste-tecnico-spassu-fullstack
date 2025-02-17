using TesteTecFullstackAngular.Api.Application.ViewModels;

namespace TesteTecFullstackAngular.Api.Domain.Interfaces
{
    public interface IBibliotecaService
    {
        #region Assuntos
        
        Task<List<AssuntoResponse>> ObterListaAssuntos(CancellationToken cancellationToken = default);
        Task<AssuntoResponse> ObterAssunto(int codigo, CancellationToken cancellationToken = default);
        Task<AssuntoResponse> CriarAssunto(AssuntoRequest request, CancellationToken cancellationToken = default);
        Task<AssuntoResponse> AlterarAssunto(int codigo, AssuntoRequest request, CancellationToken cancellationToken = default);
        Task ExcluirAssunto(int codigo, CancellationToken cancellationToken = default);

        #endregion

        #region Autores

        Task<List<AutorResponse>> ObterListaAutores(CancellationToken cancellationToken = default);
        Task<AutorResponse> ObterAutor(int codigo, CancellationToken cancellationToken = default);
        Task<AutorResponse> CriarAutor(AutorRequest request, CancellationToken cancellationToken = default);
        Task<AutorResponse> AlterarAutor(int codigo, AutorRequest request, CancellationToken cancellationToken = default);
        Task ExcluirAutor(int codigo, CancellationToken cancellationToken = default);

        #endregion

        #region Livros

        Task<List<LivroResponse>> ObterListaLivros(CancellationToken cancellationToken = default);
        Task<LivroResponse> ObterLivro(int codigo, CancellationToken cancellationToken = default);
        Task<int> CriarLivro(LivroRequest request, CancellationToken cancellationToken = default);
        Task<int> AlterarLivro(int codigo, LivroRequest request, CancellationToken cancellationToken = default);
        Task ExcluirLivro(int codigo, CancellationToken cancellationToken = default);

        #endregion
    }
}
