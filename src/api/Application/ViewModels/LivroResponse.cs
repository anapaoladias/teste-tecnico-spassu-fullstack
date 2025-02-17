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

        public List<AssuntoResponse> Assuntos { get; set; }
        public List<AutorResponse> Autores { get; set; }

        public LivroResponse(int codigo, string titulo, string editora, int edicao, string anoPublicacao, decimal valor)
        {
            Codigo = codigo;
            Titulo = titulo;
            Editora = editora;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            Valor = valor;
        }
    }
}
