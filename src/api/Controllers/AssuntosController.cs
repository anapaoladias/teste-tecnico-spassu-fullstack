using Microsoft.AspNetCore.Mvc;
using TesteTecFullstackAngular.Api.Application.ViewModels;
using TesteTecFullstackAngular.Api.Domain.Interfaces;

namespace TesteTecFullstackAngular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntosController : ControllerBase
    {
        private readonly IBibliotecaService _bibliotecaService;

        public AssuntosController(IBibliotecaService bibliotecaService)
        {
            _bibliotecaService = bibliotecaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AssuntoResponse>>> ObterLista(CancellationToken cancellationToken)
        {
            return await _bibliotecaService.ObterListaAssuntos(cancellationToken);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<AssuntoResponse>> Obter(int codigo, CancellationToken cancellationToken)
        {
            return await _bibliotecaService.ObterAssunto(codigo, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AssuntoRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _bibliotecaService.CriarAssunto(request, cancellationToken);

            // retorno 201 - criado + url para fazer o GET + registro
            return CreatedAtAction(
                nameof(Obter), 
                new { codigo = retorno.Codigo }, 
                retorno);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult<AssuntoResponse>> Alterar(int codigo, [FromBody] AssuntoRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _bibliotecaService.AlterarAssunto(codigo, request, cancellationToken);

            return Ok(retorno);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Excluir(int codigo, CancellationToken cancellationToken)
        {
            await _bibliotecaService.ExcluirAssunto(codigo, cancellationToken);

            return Ok();
        }
    }
}
