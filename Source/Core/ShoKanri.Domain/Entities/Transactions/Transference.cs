namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Transference
    (int id, int sourceId, decimal amount, Account destination) : Transaction(id, sourceId, amount)
{
    protected override void Transact(Account account)
    {
        account.Withdraw(Amount);
        
        destination.Deposit(Amount);
        destination.RegisterTransaction(this);
    }
}