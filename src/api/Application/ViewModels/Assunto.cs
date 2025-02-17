namespace TesteTecFullstackAngular.Api.Application.ViewModels
{
    public class AssuntoRequest
    {
       public string Descricao { get; set; }
    }

    public class AssuntoResponse
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public AssuntoResponse(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }

    public class AutorViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public AutorViewModel(int codigo, string Nome)
        {
            Codigo = codigo;
            this.Nome = Nome;
        }
    }

    public class LivroViewModel
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Valor { get; set; }

        public LivroViewModel(int codigo, string titulo, string editora, int edicao, string anoPublicacao, decimal valor)
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
