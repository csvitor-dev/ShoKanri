namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Income
    (int id, int accountId, decimal amount) : Transaction(id, accountId, amount)
{
    protected override void Transact(Account account)
        => account.Deposit(Amount);
}