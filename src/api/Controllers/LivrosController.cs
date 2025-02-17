using Microsoft.AspNetCore.Mvc;
using TesteTecFullstackAngular.Api.Application.ViewModels;
using TesteTecFullstackAngular.Api.Domain.Interfaces;

namespace TesteTecFullstackAngular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly IBibliotecaService _bibliotecaService;

        public LivrosController(IBibliotecaService bibliotecaService)
        {
            _bibliotecaService = bibliotecaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LivroResponse>>> ObterLista(CancellationToken cancellationToken)
        {
            return await _bibliotecaService.ObterListaLivros(cancellationToken);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<LivroResponse>> Obter(int codigo, CancellationToken cancellationToken)
        {
            return await _bibliotecaService.ObterLivro(codigo, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] LivroRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var codigo = await _bibliotecaService.CriarLivro(request, cancellationToken);
            var retorno = await _bibliotecaService.ObterLivro(codigo, cancellationToken);

            // retorno 201 - criado + url para fazer o GET + registro
            return CreatedAtAction(
                nameof(Obter),
                new { codigo },
                retorno);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult<LivroResponse>> Alterar(int codigo, [FromBody] LivroRequest request, CancellationToken cancellationToken)
        {
            await _bibliotecaService.AlterarLivro(codigo, request, cancellationToken);

            var retorno = await _bibliotecaService.ObterLivro(codigo, cancellationToken);
            return Ok(retorno);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Excluir(int codigo, CancellationToken cancellationToken)
        {
            await _bibliotecaService.ExcluirLivro(codigo, cancellationToken);

            return Ok();
        }
    }
}
