using FluentValidation;

namespace TesteTecFullstackAngular.Api.Application.ViewModels
{
    public class AssuntoRequest
    {
        public string Descricao { get; set; }
    }

    public class AssuntoRequestValidator : AbstractValidator<AssuntoRequest>
    {
        public AssuntoRequestValidator()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição não pode estar vazia.")
                .MaximumLength(20).WithMessage("A descrição deve ter no máximo 20 caracteres.");
        }
    }
}
