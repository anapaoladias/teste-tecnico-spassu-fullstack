namespace TesteTecFullstackAngular.Api.Domain.Entities
{
    public class Assunto
    {
        public int CodAs { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<LivroAssunto> LivroAssuntos { get; set; }
    }
}
