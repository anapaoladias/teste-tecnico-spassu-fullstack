using Microsoft.AspNetCore.Mvc;
using TesteTecFullstackAngular.Api.Application.ViewModels;
using TesteTecFullstackAngular.Api.Domain.Interfaces;

namespace TesteTecFullstackAngular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IBibliotecaService _bibliotecaService;

        public AutoresController(IBibliotecaService bibliotecaService)
        {
            _bibliotecaService = bibliotecaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorResponse>>> ObterLista(CancellationToken cancellationToken)
        {
            return await _bibliotecaService.ObterListaAutores(cancellationToken);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<AutorResponse>> Obter(int codigo, CancellationToken cancellationToken)
        {
            return await _bibliotecaService.ObterAutor(codigo, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AutorRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _bibliotecaService.CriarAutor(request, cancellationToken);

            // retorno 201 - criado + url para fazer o GET + registro
            return CreatedAtAction(
                nameof(Obter),
                new { codigo = retorno.Codigo },
                retorno);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult<AutorResponse>> Alterar(int codigo, [FromBody] AutorRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _bibliotecaService.AlterarAutor(codigo, request, cancellationToken);

            return Ok(retorno);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Excluir(int codigo, CancellationToken cancellationToken)
        {
            await _bibliotecaService.ExcluirAutor(codigo, cancellationToken);

            return Ok();
        }
    }
}
