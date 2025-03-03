namespace ShoKanri.Domain.Entities.Transactions;

public abstract class Transaction
    (int id, int accountId, decimal amount)
{
    public int Id { get; init; } = id;
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.Now;
    public int AccountId { get; init; } = accountId;
    public decimal Amount { get; protected set; } = amount;
    
    protected abstract void Transact(Account account);

    public void Execute(Account account)
    {
        Transact(account);
        account.RegisterTransaction(this);
    }
}