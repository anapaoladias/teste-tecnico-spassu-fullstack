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
                .NotEmpty().WithMessage("O Nome não pode estar vazia.")
                .MaximumLength(20).WithMessage("O Nome deve ter no máximo 40 caracteres.");
        }
    }
}
