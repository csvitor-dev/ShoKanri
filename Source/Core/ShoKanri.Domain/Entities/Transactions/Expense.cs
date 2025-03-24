namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Expense
: Transaction
{
    protected override void Transact(Account account)
        => account.Withdraw(Amount);
}