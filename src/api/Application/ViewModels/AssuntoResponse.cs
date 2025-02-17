namespace TesteTecFullstackAngular.Api.Application.ViewModels
{
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
}
