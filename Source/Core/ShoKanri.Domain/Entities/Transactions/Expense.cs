namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Expense
    (int id, int accountId, decimal amount) : Transaction(id, accountId, amount)
{
    protected override void Transact(Account account)
        => account.Withdraw(Amount);
}