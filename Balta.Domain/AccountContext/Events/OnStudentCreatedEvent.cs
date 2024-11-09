using Balta.Domain.SharedContext.Events.Abstractions;

namespace Balta.Domain.AccountContext.Events;

public sealed record OnStudentCreatedEvent(Guid Id, string Name, string Email) : IDomainEvent;