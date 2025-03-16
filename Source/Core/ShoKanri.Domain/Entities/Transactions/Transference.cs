namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Transference : Transaction
{
    public readonly Account? destination;

    protected override void Transact(Account account)
    {
        account.Withdraw(Amount);

        if(destination is null) throw new InvalidOperationException("invalid destination account");
        
        destination.Deposit(Amount);
        destination.RegisterTransaction(this);
    }
}