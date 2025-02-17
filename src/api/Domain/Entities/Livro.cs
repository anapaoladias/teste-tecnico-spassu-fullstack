using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TesteTecFullstackAngular.Api.Domain.Entities
{
    public class Livro
    {
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        public virtual ICollection<LivroAutor> LivroAutores { get; set; }
        public virtual ICollection<LivroAssunto> LivroAssuntos { get; set; }
    }

    public class Assunto
    {
        public int CodAs { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<LivroAssunto> LivroAssuntos { get; set; }
    }

    public class LivroAutor
    {
        public int Livro_CodI { get; set; }
        public int Autor_CodAu { get; set; }

        public virtual Livro Livro { get; set; }
        public virtual Autor Autor { get; set; }
    }

    public class LivroAssunto
    {
        public int Livro_CodI { get; set; }
        public int Assunto_codAs { get; set; }

        public virtual Livro Livro { get; set; }
        public virtual Assunto Assunto { get; set; }
    }
}
