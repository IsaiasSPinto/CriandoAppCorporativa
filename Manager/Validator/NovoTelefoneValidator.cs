using Core.ModelViews;
using FluentValidation;

namespace Manager.Validator;
public class NovoTelefoneValidator : AbstractValidator<NovoTelefone>
{
    public NovoTelefoneValidator()
    {
        RuleFor(p => p.Numero).NotEmpty().NotNull().Matches("[2-9][0-9]{10}").WithMessage("O telefone tem que ter o fotmato");
    }
}
