namespace TesteTecFullstackAngular.Api.Application.ViewModels
{
    public class LivroResponse
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Valor { get; set; }

        public string Assunto { get; set; }
        public string Autor { get; set; }

        public LivroResponse(int codigo, string titulo, string editora, int edicao, string anoPublicacao, decimal valor, string assunto, string autor)
        {
            Codigo = codigo;
            Titulo = titulo;
            Editora = editora;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            Valor = valor;

            Assunto = assunto;
            Autor = autor;
        }
    }
}
