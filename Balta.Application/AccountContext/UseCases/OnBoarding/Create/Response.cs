using Balta.Application.SharedContext.UseCases.Abstractions;

namespace Balta.Application.AccountContext.UseCases.OnBoarding.Create;

public sealed record Response(Guid Id, string Name, string Email) : ICommandResponse;