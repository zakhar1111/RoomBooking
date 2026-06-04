namespace RoomBooking.Domain;

public abstract class Entity<TId> 
    : IEquatable<Entity<TId>> where TId : notnull
{
    public TId Id { get; protected set; } = default!;

    protected Entity(TId id)
    {
        if (EqualityComparer<TId>.Default.Equals(id, default!))
        {
            throw new ArgumentException("The ID cannot be the default value.", nameof(id));
        }
        Id = id;
    }

    // Required for EF Core 
    protected Entity() { }

    // --- Equality Logic (Crucial for DDD Entities) ---

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        if (IsTransient() || other.IsTransient()) return false;

        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public bool Equals(Entity<TId>? other) => Equals((object?)other);

    public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Entity<TId>? a, Entity<TId>? b) => !(a == b);

    public override int GetHashCode()
    {
        // If transient, use base implementation to avoid hash collisions on default(TId)
        return IsTransient() ? base.GetHashCode() : Id.GetHashCode();
    }

    // An entity is transient if it hasn't been assigned an ID yet (e.g., ID is 0 or Empty Guid)
    private bool IsTransient() => EqualityComparer<TId>.Default.Equals(Id, default!);
}