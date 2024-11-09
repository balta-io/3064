using Balta.Application.SharedContext.UseCases.Abstractions;
using Balta.Domain.AccountContext.Enums;

namespace Balta.Application.AccountContext.UseCases.OnBoarding.Create;

public sealed record Command(EAccountType Type, string FirstName, string LastName, string Email, string Cpf, string Password) : ICommand<Response>;