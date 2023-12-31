﻿using Core.ModelViews.Cliente;
using FluentValidation;

namespace Manager.Validator;

public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
{
    public AlteraClienteValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new NovoClienteValidator());
    }
}

