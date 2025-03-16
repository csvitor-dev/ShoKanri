namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Transference : Transaction
{
    public readonly Account? Destination;

    protected override void Transact(Account account)
    {
        account.Withdraw(Amount);

        if(Destination is null) throw new InvalidOperationException("invalid destination account");
        
        Destination.Deposit(Amount);
        Destination.RegisterTransaction(this);
    }
}