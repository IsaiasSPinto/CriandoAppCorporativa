﻿using Core.ModelViews;
using FluentValidation;

namespace Manager.Validator;

public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
{
    public NovoEnderecoValidator()
    {
        RuleFor(p => p.CEP).NotEmpty().NotNull();
        RuleFor(p => p.Estado).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(p => p.Cidade).NotEmpty().NotNull().MaximumLength(200);
        RuleFor(p => p.Logradouro).NotEmpty().NotNull().MaximumLength(200);
        RuleFor(p => p.Numero).NotEmpty().NotNull().MaximumLength(10);
        RuleFor(p => p.Complemento).MaximumLength(200);
    }
}
