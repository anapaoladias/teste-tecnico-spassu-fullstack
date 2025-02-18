using TesteTecFullstackAngular.Api.Application.ViewModels;
using TesteTecFullstackAngular.Api.Domain.Views;

namespace TesteTecFullstackAngular.Api.Domain.Interfaces
{
    public interface IRelatoriosService
    {
        Task<List<LivrosListaCompletaView>> ObterLivrosCompleta(CancellationToken cancellationToken = default);
        Task<List<LivrosAgrupadoAutorResponse>> ObterLivrosAgrupadaPorAutor(CancellationToken cancellationToken = default);
    }
}
