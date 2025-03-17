namespace ShoKanri.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.Now.UtcDateTime;
}