using TesteTecFullstackAngular.Api.Application.ViewModels;

namespace TesteTecFullstackAngular.Api.Domain.Interfaces
{
    public interface IBibliotecaService
    {
        #region Assuntos
        
        Task<List<AssuntoResponse>> ObterLista(CancellationToken cancellationToken = default);
        Task<AssuntoResponse> ObterAssunto(int codigo, CancellationToken cancellationToken = default);
        Task<AssuntoResponse> CriarAssunto(AssuntoRequest request, CancellationToken cancellationToken = default);
        Task<AssuntoResponse> AlterarAssunto(int codigo, AssuntoRequest request, CancellationToken cancellationToken = default);
        Task ExcluirAssunto(int codigo, CancellationToken cancellationToken = default);

        #endregion
    }
}
