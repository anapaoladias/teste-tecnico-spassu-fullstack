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

        public int CodigoAssunto { get; set; }
        public int CodigoAutor { get; set; }
    }

    public class LivroRequestValidator : AbstractValidator<LivroRequest>
    {
        public LivroRequestValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(40).WithMessage("O título deve ter no máximo 40 caracteres.");

            RuleFor(x => x.Editora)
                .NotEmpty().WithMessage("A editora é obrigatória.")
                .MaximumLength(40).WithMessage("A editora deve ter no máximo 40 caracteres.");

            RuleFor(x => x.Edicao)
                .GreaterThan(0).WithMessage("A edição deve ser maior que zero.");

            RuleFor(x => x.AnoPublicacao)
                .Matches(@"^\d{4}$").WithMessage("O ano de publicação deve ter 4 dígitos.");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");

            RuleFor(x => x.CodigoAssunto)
                .GreaterThan(0).WithMessage("O Assunto deve ser informado.");

            RuleFor(x => x.CodigoAutor)
                .GreaterThan(0).WithMessage("O Autor deve ser informado.");
        }
    }
}
