namespace TesteTecFullstackAngular.Api.Domain.Entities
{
    public class LivroAutor
    {
        public int Livro_CodI { get; set; }
        public int Autor_CodAu { get; set; }

        public virtual Livro Livro { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
