using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Application.ViewModels;
using TesteTecFullstackAngular.Api.Core;
using TesteTecFullstackAngular.Api.Domain.Entities;
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
                .Include(i => i.LivroAssuntos).ThenInclude(i => i.Assunto)
                .Include(i => i.LivroAutores).ThenInclude(i => i.Autor)
                .ToListAsync(cancellationToken);

            var retorno = new List<LivroResponse>();

            foreach (var r in registros)
            {
                var livro = new LivroResponse(r.Codl, r.Titulo, r.Editora, r.Edicao, r.AnoPublicacao, r.Valor);

                livro.Autores = r.LivroAutores.Select(q => new AutorResponse(q.Autor.CodAu, q.Autor.Nome)).ToList();
                livro.Assuntos = r.LivroAssuntos.Select(q => new AssuntoResponse(q.Assunto.CodAs, q.Assunto.Descricao)).ToList();

                retorno.Add(livro);
            }

            return retorno;
        }

        public async Task<LivroResponse> ObterLivro(int codigo, CancellationToken cancellationToken = default)
        {
            var registro = await _context.Livros
                .Include(i => i.LivroAssuntos).ThenInclude(i => i.Assunto)
                .Include(i => i.LivroAutores).ThenInclude(i => i.Autor)
                .FirstOrDefaultAsync(q => q.Codl == codigo, cancellationToken);

            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "LIVRO_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            var retorno = new LivroResponse(registro.Codl, registro.Titulo, registro.Editora, registro.Edicao, registro.AnoPublicacao, registro.Valor);

            retorno.Autores = registro.LivroAutores.Select(q => new AutorResponse(q.Autor.CodAu, q.Autor.Nome)).ToList();
            retorno.Assuntos = registro.LivroAssuntos.Select(q => new AssuntoResponse(q.Assunto.CodAs, q.Assunto.Descricao)).ToList();

            return retorno;
        }

        public async Task<int> CriarLivro(LivroRequest request, CancellationToken cancellationToken = default)
        {
            var registroDuplicado = await _context.Livros.FirstOrDefaultAsync(q => q.Titulo.Trim().ToUpper() == request.Titulo.Trim().ToUpper(), cancellationToken);
            if (registroDuplicado != null)
                throw new BusinessException("Livro já cadastrado!", "LIVRO_DUPLICADO", StatusCodes.Status400BadRequest);

            // Livro
            var entidade = new Domain.Entities.Livro
            {
                Titulo = request.Titulo.Trim(),
                Editora = request.Editora,
                Edicao = request.Edicao,
                AnoPublicacao = request.AnoPublicacao,
                Valor = request.Valor,
                LivroAutores = new List<LivroAutor>(),
                LivroAssuntos = new List<LivroAssunto>(),
            };

            // Autores
            var autores = await _context.Autores.Where(q => request.Autores.Select(q => q.Codigo).Contains(q.CodAu)).ToListAsync();
            autores.ForEach(a => entidade.LivroAutores.Add(new Domain.Entities.LivroAutor()
            {
                Autor = a,
                Livro = entidade
            }));

            // Assuntos
            var assuntos = await _context.Assuntos.Where(q => request.Assuntos.Select(q => q.Codigo).Contains(q.CodAs)).ToListAsync();
            assuntos.ForEach(a => entidade.LivroAssuntos.Add(new Domain.Entities.LivroAssunto()
            {
                Assunto = a,
                Livro = entidade
            }));

            await _context.Livros.AddAsync(entidade, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entidade.Codl;
        }
        public async Task<int> AlterarLivro(int codigo, LivroRequest request, CancellationToken cancellationToken = default)
        {
            var registroDuplicado = await _context.Livros.FirstOrDefaultAsync(q => q.Titulo.Trim().ToUpper() == request.Titulo.Trim().ToUpper() && q.Codl != codigo, cancellationToken);
            if (registroDuplicado != null)
                throw new BusinessException("Livro já cadastrado!", "LIVRO_DUPLICADO", StatusCodes.Status400BadRequest);

            var registro = await _context.Livros
                .Include(i => i.LivroAssuntos).ThenInclude(i => i.Assunto)
                .Include(i => i.LivroAutores).ThenInclude(i => i.Autor)
                .FirstOrDefaultAsync(q => q.Codl == codigo, cancellationToken);
            if (registro == null)
                throw new BusinessException("Registro não encontrado!", "LIVRO_NAO_ENCONTRADO", StatusCodes.Status404NotFound);

            // Livro
            registro.Titulo = request.Titulo.Trim();
            registro.Editora = request.Editora;
            registro.Edicao = request.Edicao;
            registro.AnoPublicacao = request.AnoPublicacao;
            registro.Valor = request.Valor;

            // Autores
            registro.LivroAutores.Clear();
            var autores = await _context.Autores.Where(q => request.Autores.Select(q => q.Codigo).Contains(q.CodAu)).ToListAsync();
            autores.ForEach(a => registro.LivroAutores.Add(new Domain.Entities.LivroAutor()
            {
                Autor = a,
                Livro = registro
            }));

            // Assuntos
            registro.LivroAssuntos.Clear();
            var assuntos = await _context.Assuntos.Where(q => request.Assuntos.Select(q => q.Codigo).Contains(q.CodAs)).ToListAsync();
            assuntos.ForEach(a => registro.LivroAssuntos.Add(new Domain.Entities.LivroAssunto()
            {
                Assunto = a,
                Livro = registro
            }));

            await _context.SaveChangesAsync(cancellationToken);

            return registro.Codl;
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
