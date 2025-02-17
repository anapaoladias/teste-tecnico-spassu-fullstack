namespace TesteTecFullstackAngular.Api.Application.ViewModels
{
    public class AutorResponse
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public AutorResponse(int codigo, string Nome)
        {
            Codigo = codigo;
            this.Nome = Nome;
        }
    }
}
