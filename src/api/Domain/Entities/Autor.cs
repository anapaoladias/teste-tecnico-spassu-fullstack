namespace TesteTecFullstackAngular.Api.Domain.Entities
{
    public class Autor
    {
        public int CodAu { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<LivroAutor> LivroAutores { get; set; }
    }
}
