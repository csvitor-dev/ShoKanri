namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Transference
: Transaction
{
    private readonly Account? destination;

    private Transference () {}

    public Transference(int id, int sourceId, decimal amount, Account destination) : base(id, sourceId, amount)
    {
        this.destination = destination;
    }

    protected override void Transact(Account account)
    {
        account.Withdraw(Amount);

        if(destination is null) throw new InvalidOperationException("invalid destination account");
        
        destination.Deposit(Amount);
        destination.RegisterTransaction(this);
    }
}