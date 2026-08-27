namespace Tax_Radar_Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // Values set here are overwritten by EF Core's property setters when materializing an existing row,
    // so this also doubles as the EF Core constructor for every derived entity.
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    protected void MarkAsUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public override bool Equals(object? obj) =>
        obj is BaseEntity other && other.GetType() == GetType() && other.Id == Id;

    public override int GetHashCode() => (GetType(), Id).GetHashCode();
}
