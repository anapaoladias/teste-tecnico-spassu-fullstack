using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Application.ViewModels;
using TesteTecFullstackAngular.Api.Core;
using TesteTecFullstackAngular.Api.Domain.Interfaces;
using TesteTecFullstackAngular.Api.Infra.ORM;

namespace TesteTecFullstackAngular.Api.Application.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private readonly DefaultContext _context;

        public BibliotecaService(DefaultContext context)
        {
            _context = context;
        }

        #region Assuntos

        public async Task<List<AssuntoResponse>> ObterListaAssuntos(CancellationToken cancellationToken = default)
        {
            var registros = await _context.Assuntos.ToListAsync(cancellationToken);

            return registros.Select(q => new AssuntoResponse(q.CodAs, q.Descricao)).ToList();
        }

        public async Task<AssuntoResponse> ObterAssunto(int codigo, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Assuntos.FirstOrDefaultAsync(q => q.CodAs == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "ASSUNTO_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            return new AssuntoResponse(registro.CodAs, registro.Descricao);
        }

        public async Task<AssuntoResponse> CriarAssunto(AssuntoRequest request, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Assuntos.FirstOrDefaultAsync(q => q.Descricao.Trim().ToUpper() == request.Descricao.Trim().ToUpper(), cancellationToken);
            if (registro != null)
                throw new BusinessException("Assunto já cadastrado!", "ASSUNTO_DUPLICADO", StatusCodes.Status400BadRequest);

            var entidade = new Domain.Entities.Assunto
            {
                Descricao = request.Descricao
            };

            await _context.Assuntos.AddAsync(entidade, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new AssuntoResponse(entidade.CodAs, entidade.Descricao);
        }

        public async Task<AssuntoResponse> AlterarAssunto(int codigo, AssuntoRequest request, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Assuntos.FirstOrDefaultAsync(q => q.CodAs == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "ASSUNTO_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            registro.Descricao = request.Descricao;

            await _context.SaveChangesAsync(cancellationToken);

            return new AssuntoResponse(registro.CodAs, registro.Descricao);
        }

        public async Task ExcluirAssunto(int codigo, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Assuntos.FirstOrDefaultAsync(q => q.CodAs == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "ASSUNTO_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            // TODO: validar referencias FK

            _context.Assuntos.Remove(registro);
            await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
