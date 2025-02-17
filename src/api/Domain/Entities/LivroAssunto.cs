namespace TesteTecFullstackAngular.Api.Domain.Entities
{
    public class LivroAssunto
    {
        public int Livro_CodI { get; set; }
        public int Assunto_codAs { get; set; }

        public virtual Livro Livro { get; set; }
        public virtual Assunto Assunto { get; set; }
    }
}
