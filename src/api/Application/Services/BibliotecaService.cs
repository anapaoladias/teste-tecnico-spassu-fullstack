using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Drawing;
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
            var registroDuplicado = await _context.Assuntos.FirstOrDefaultAsync(q => q.Descricao.Trim().ToUpper() == request.Descricao.Trim().ToUpper(), cancellationToken);
            if (registroDuplicado != null)
                throw new BusinessException("Assunto já cadastrado!", "ASSUNTO_DUPLICADO", StatusCodes.Status400BadRequest);

            var entidade = new Domain.Entities.Assunto
            {
                Descricao = request.Descricao.Trim()
            };

            await _context.Assuntos.AddAsync(entidade, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new AssuntoResponse(entidade.CodAs, entidade.Descricao);
        }

        public async Task<AssuntoResponse> AlterarAssunto(int codigo, AssuntoRequest request, CancellationToken cancellationToken = default)
        {
            var registroDuplicado = await _context.Assuntos.FirstOrDefaultAsync(q => q.Descricao.Trim().ToUpper() == request.Descricao.Trim().ToUpper() && q.CodAs != codigo, cancellationToken);
            if (registroDuplicado != null)
                throw new BusinessException("Assunto já cadastrado!", "ASSUNTO_DUPLICADO", StatusCodes.Status400BadRequest);

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

        #region Autores

        public async Task<List<AutorResponse>> ObterListaAutores(CancellationToken cancellationToken = default)
        {
            var registros = await _context.Autores.ToListAsync(cancellationToken);

            return registros.Select(q => new AutorResponse(q.CodAu, q.Nome)).ToList();
        }

        public async Task<AutorResponse> ObterAutor(int codigo, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Autores.FirstOrDefaultAsync(q => q.CodAu == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "AUTOR_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            return new AutorResponse(registro.CodAu, registro.Nome);
        }

        public async Task<AutorResponse> CriarAutor(AutorRequest request, CancellationToken cancellationToken = default)
        {
            var registroDuplicado = await _context.Autores.FirstOrDefaultAsync(q => q.Nome.Trim().ToUpper() == request.Nome.Trim().ToUpper(), cancellationToken);
            if (registroDuplicado != null)
                throw new BusinessException("Autor já cadastrado!", "AUTOR_DUPLICADO", StatusCodes.Status400BadRequest);

            var entidade = new Domain.Entities.Autor
            {
                Nome = request.Nome.Trim()
            };

            await _context.Autores.AddAsync(entidade, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new AutorResponse(entidade.CodAu, entidade.Nome);
        }

        public async Task<AutorResponse> AlterarAutor(int codigo, AutorRequest request, CancellationToken cancellationToken = default)
        {
            var registroDuplicado = await _context.Autores.FirstOrDefaultAsync(q => q.Nome.Trim().ToUpper() == request.Nome.Trim().ToUpper() && q.CodAu != codigo, cancellationToken);
            if (registroDuplicado != null)
                throw new BusinessException("Autor já cadastrado!", "AUTOR_DUPLICADO", StatusCodes.Status400BadRequest);

            var registro = await _context.Autores.FirstOrDefaultAsync(q => q.CodAu == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "AUTOR_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            registro.Nome = request.Nome;

            await _context.SaveChangesAsync(cancellationToken);

            return new AutorResponse(registro.CodAu, registro.Nome);
        }

        public async Task ExcluirAutor(int codigo, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Autores.FirstOrDefaultAsync(q => q.CodAu == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "AUTOR_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            // TODO: validar referencias FK

            _context.Autores.Remove(registro);
            await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Livros

        public async Task<List<LivroResponse>> ObterListaLivros(CancellationToken cancellationToken = default)
        {
            var registros = await _context.Livros
                .Include("LivroAutores.Livro")
                .Include("LivroAssunto.Assunto")
                .ToListAsync(cancellationToken);

            var retorno = registros
                .Select(q => new LivroResponse(q.Codl, q.Titulo, q.Editora, q.Edicao, q.AnoPublicacao, q.Valor))
                .ToList();

            return retorno;
        }

        public async Task<LivroResponse> ObterLivro(int codigo, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Livros.FirstOrDefaultAsync(q => q.Codl == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "LIVRO_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            return new LivroResponse(registro.Codl, registro.Titulo, registro.Editora, registro.Edicao, registro.AnoPublicacao, registro.Valor);
        }

        public async Task<LivroResponse> CriarLivro(LivroRequest request, CancellationToken cancellationToken = default)
        {
            var registroDuplicado = await _context.Livros.FirstOrDefaultAsync(q => q.Titulo.Trim().ToUpper() == request.Titulo.Trim().ToUpper(), cancellationToken);
            if (registroDuplicado != null)
                throw new BusinessException("Livro já cadastrado!", "LIVRO_DUPLICADO", StatusCodes.Status400BadRequest);

            var entidade = new Domain.Entities.Livro
            {
                Titulo = request.Titulo.Trim(),
                Editora = request.Editora,
                Edicao = request.Edicao,
                AnoPublicacao = request.AnoPublicacao,
                Valor = request.Valor
            };

            await _context.Livros.AddAsync(entidade, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new LivroResponse(entidade.Codl, entidade.Titulo, entidade.Editora, entidade.Edicao, entidade.AnoPublicacao, entidade.Valor);
        }
        public async Task<LivroResponse> AlterarLivro(int codigo, LivroRequest request, CancellationToken cancellationToken = default)
        {
            var registroDuplicado = await _context.Livros.FirstOrDefaultAsync(q => q.Titulo.Trim().ToUpper() == request.Titulo.Trim().ToUpper() && q.Codl != codigo, cancellationToken);
            if (registroDuplicado != null)
                throw new BusinessException("Livro já cadastrado!", "LIVRO_DUPLICADO", StatusCodes.Status400BadRequest);

            var registro = await _context.Livros.FirstOrDefaultAsync(q => q.Codl == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "LIVRO_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            registro.Titulo = request.Titulo.Trim();
            registro.Editora = request.Editora;
            registro.Edicao = request.Edicao;
            registro.AnoPublicacao = request.AnoPublicacao;
            registro.Valor = request.Valor;

            await _context.SaveChangesAsync(cancellationToken);

            return new LivroResponse(registro.Codl, registro.Titulo, registro.Editora, registro.Edicao, registro.AnoPublicacao, registro.Valor);
        }

        public async Task ExcluirLivro(int codigo, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Livros.FirstOrDefaultAsync(q => q.Codl == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "LIVRO_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            _context.Livros.Remove(registro);
            await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
