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
}
