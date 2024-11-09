using Balta.Domain.SharedContext.Events.Abstractions;

namespace Balta.Domain.AccountContext.Events;

public sealed record OnCorporationCreatedEvent(Guid Id, string Name, string Email) : IDomainEvent;