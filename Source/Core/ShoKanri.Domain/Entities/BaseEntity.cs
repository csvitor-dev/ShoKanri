namespace ShoKanri.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; init; }
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.Now;
    public DateTimeOffset UpdatedOn { get; protected set; }
    public bool Active { get; protected set; } = true;
}