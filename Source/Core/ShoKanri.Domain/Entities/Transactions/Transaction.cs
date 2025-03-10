namespace ShoKanri.Domain.Entities.Transactions;

public abstract class Transaction
    (int id, int accountId, decimal amount) : BaseEntity(id)
{
    public int AccountId { get; init; } = accountId;
    public decimal Amount { get; protected set; } = amount;
    
    protected abstract void Transact(Account account);

    public void Execute(Account account)
    {
        Transact(account);
        account.RegisterTransaction(this);
    }
}