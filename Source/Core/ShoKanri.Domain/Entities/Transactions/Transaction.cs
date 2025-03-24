namespace ShoKanri.Domain.Entities.Transactions;

public abstract class Transaction : BaseEntity
{
    public int AccountId { get; init; }
    public decimal Amount { get; set; }

    public virtual Account? Account { get; set; }

    protected abstract void Transact(Account account);

    public void Execute(Account account)
    {
        Transact(account);
        account.RegisterTransaction(this);
    }
}