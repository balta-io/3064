using Balta.Domain.SharedContext.Events.Abstractions;
using Balta.Domain.SharedContext.ValueObjects;

namespace Balta.Domain.SharedContext.Entities;

public abstract class Entity(Guid id, Tracker tracker) : IEquatable<Guid>
{
    #region Private Properties

    private readonly List<IDomainEvent> _domainEvents = [];

    #endregion

    #region Properties

    public Guid Id { get; } = id;
    public Tracker Tracker { get; } = tracker;

    #endregion

    #region Public Methods

    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents;

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);

    #endregion

    #region Equatable Implementation

    public bool Equals(Guid id)
    {
        return Id == id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    #endregion
}