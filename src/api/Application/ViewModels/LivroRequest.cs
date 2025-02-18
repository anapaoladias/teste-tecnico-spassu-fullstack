using FluentValidation;

namespace TesteTecFullstackAngular.Api.Application.ViewModels
{
    public class LivroRequest
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Valor { get; set; }

        public List<int> CodigosAssuntos { get; set; }
        public List<int> CodigosAutores { get; set; }
    }

    public class LivroRequestValidator : AbstractValidator<LivroRequest>
    {
        public LivroRequestValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O Título é obrigatório.")
                .MaximumLength(40).WithMessage("O título deve ter no máximo 40 caracteres.");

            RuleFor(x => x.Editora)
                .NotEmpty().WithMessage("A Editora é obrigatória.")
                .MaximumLength(40).WithMessage("A editora deve ter no máximo 40 caracteres.");

            RuleFor(x => x.Edicao)
                .GreaterThan(0).WithMessage("A Edição deve ser maior que zero.");

            RuleFor(x => x.AnoPublicacao)
                .Matches(@"^\d{4}$").WithMessage("O Ano de Publicação deve ter 4 dígitos.");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O Valor deve ser maior que zero.");

            RuleFor(x => x.CodigosAssuntos)
                .NotEmpty().WithMessage("Informe o Assunto");

            RuleFor(x => x.CodigosAutores)
                .NotEmpty().WithMessage("Informe os Autores");
        }
    }
}
