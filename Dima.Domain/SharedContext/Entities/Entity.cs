using Dima.Domain.SharedContext.Events.Abstractions;

namespace Dima.Domain.SharedContext.Entities;
public abstract class Entity
{
    #region Private Properties
    
    private readonly List<IDomainEvent> _domainEvents = new();

    #endregion

    #region Constructors

    protected Entity(Guid id) => Id = id;

    protected Entity()
    {
    }

    #endregion

    #region Properties

    public Guid Id { get; init; }

    #endregion

    #region Public Methods

    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    #endregion
}
