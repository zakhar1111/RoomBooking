namespace RoomBooking.Domain;

using System.Collections.Generic;

public interface IDomainEvent { }

public abstract class AggregateRoot<TId> 
    : Entity<TId> where TId : notnull
{
    // Internal tracking events
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected AggregateRoot(TId id) 
        : base(id) { }

    // for EF core
    protected AggregateRoot() { }

    // raise events
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    // repository calls it after successfully saving to the database
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
