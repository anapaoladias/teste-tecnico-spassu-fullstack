using Microsoft.AspNetCore.Mvc;
using TesteTecFullstackAngular.Api.Application.ViewModels;
using TesteTecFullstackAngular.Api.Domain.Interfaces;
using TesteTecFullstackAngular.Api.Domain.Views;

namespace TesteTecFullstackAngular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatoriosService _relatoriosService;

        public RelatoriosController(IRelatoriosService relatoriosService)
        {
            _relatoriosService = relatoriosService;
        }

        [HttpGet("livros/lista-completa")]
        public async Task<ActionResult<List<LivrosListaCompletaView>>> ObterLivrosListaCompleta(CancellationToken cancellationToken)
        {
            return await _relatoriosService.ObterLivrosCompleta(cancellationToken);
        }

        [HttpGet("livros/lista-agrupada-autor")]
        public async Task<ActionResult<List<LivrosAgrupadoAutorResponse>>> ObterLivrosListaAgrupadaAutor(CancellationToken cancellationToken)
        {
            return await _relatoriosService.ObterLivrosAgrupadaPorAutor(cancellationToken);
        }
    }
}
