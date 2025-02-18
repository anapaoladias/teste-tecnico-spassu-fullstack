using FluentValidation;

namespace TesteTecFullstackAngular.Api.Application.ViewModels
{
    public class AutorRequest
    {
        public string Nome { get; set; }
    }

    public class AutorRequestValidator : AbstractValidator<AutorRequest>
    {
        public AutorRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .MaximumLength(40).WithMessage("O Nome deve ter no máximo 40 caracteres.");
        }
    }
}
