using Balta.Domain.SharedContext.Events.Abstractions;

namespace Balta.Domain.AccountContext.Events;

public sealed record OnResendEmailVerificationEvent(Guid Id, string Name, string Email, string VerificationCode) : IDomainEvent;