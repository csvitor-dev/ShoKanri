using ShoKanri.Domain.Entities.Enums;

namespace ShoKanri.Domain.Entities.Transactions;

public abstract class Transaction : BaseEntity
{
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public EMovementKind MovementKind { get; set; }
    public string Description { get; set; } = string.Empty;

    public virtual Account? Account { get; set; }

    protected abstract void Transact(Account account);

    public void Execute(Account account)
    {
        Transact(account);
        account.RegisterTransaction(this);
    }
}