namespace TesteTecFullstackAngular.Api.Application.ViewModels
{
    public class LivrosAgrupadoAutorResponse
    {
        public int CodigoAutor { get; set; }
        public string Autor { get; set; }
        public List<LivrosAgrupadoAutorItensResponse> Livros { get; set; }
    }

    public class LivrosAgrupadoAutorItensResponse
    {
        public int CodigoLivro { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Valor { get; set; }
        public string Assuntos { get; set; }
    }
}
