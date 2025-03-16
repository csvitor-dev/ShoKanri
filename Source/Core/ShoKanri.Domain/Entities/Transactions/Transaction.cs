namespace ShoKanri.Domain.Entities.Transactions;

public abstract class Transaction
: BaseEntity
{
    public int AccountId { get; init; }
    public decimal Amount { get; protected set; }

    protected Transaction () {}

    public Transaction(int id, int accountId, decimal amount) : base(id)
    {
        AccountId = accountId;
        Amount = amount;
    }

    protected abstract void Transact(Account account);

    public void Execute(Account account)
    {
        Transact(account);
        account.RegisterTransaction(this);
    }
}