using Balta.Domain.AccountContext.Enums;
using FluentValidation;

namespace Balta.Application.AccountContext.UseCases.OnBoarding.Create;

public sealed class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Type).NotEqual(EAccountType.Corporation).WithMessage("Tipo de conta não suportado");

        RuleFor(x => x.FirstName).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("O nome deve conter pelo menos 3 caracteres.");
        RuleFor(x => x.FirstName).MaximumLength(40).WithMessage("O nome deve conter no máximo 40 caracteres.");

        RuleFor(x => x.LastName).NotEmpty().WithMessage("O sobrenome é obrigatório.");
        RuleFor(x => x.LastName).MinimumLength(3).WithMessage("O sobrenome deve conter pelo menos 3 caracteres.");
        RuleFor(x => x.LastName).MaximumLength(40).WithMessage("O sobrenome deve conter no máximo 40 caracteres.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("O E-mail é obrigatório.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("O E-mail informado é inválido.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("A senha é obrigatória.");
        RuleFor(x => x.Password).MinimumLength(8).WithMessage("A senha deve conter pelo menos 3 caracteres.");
        RuleFor(x => x.Password).MaximumLength(40).WithMessage("A senha deve conter no máximo 40 caracteres.");

        RuleFor(x => x.Cpf).NotEmpty().WithMessage("O CPF é obrigatório.");
        RuleFor(x => x.Cpf).MinimumLength(11).WithMessage("O CPF deve conter 11 caracteres.");
        RuleFor(x => x.Cpf).MaximumLength(11).WithMessage("O CPF deve conter 11 caracteres.");
    }
}