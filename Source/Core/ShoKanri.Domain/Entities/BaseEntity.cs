namespace ShoKanri.Domain.Entities;

public abstract class BaseEntity(int id)
{
    public int Id { get; } = id;
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.Now;
    public DateTimeOffset UpdatedOn { get; protected set; }  = DateTimeOffset.Now;
    public bool Active { get; protected set; } = true;
}