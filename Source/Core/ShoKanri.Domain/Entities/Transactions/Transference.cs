namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Transference : Transaction
{
    public Account? Destination { get; init; }

    protected override void Transact(Account account)
    {
        account.Withdraw(Amount);

        if(Destination is null) throw new InvalidOperationException("invalid destination account");
        
        Destination.Deposit(Amount);
        Destination.RegisterTransaction(this);
    }
}