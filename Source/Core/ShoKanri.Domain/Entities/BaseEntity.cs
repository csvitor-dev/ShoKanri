namespace ShoKanri.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(){}
    public BaseEntity(int id)
    {
        Id = id;
    }

    public int Id { get; }
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.Now.UtcDateTime;

}