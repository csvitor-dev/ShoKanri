namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Income
: Transaction
{
    protected override void Transact(Account account)
        => account.Deposit(Amount);
}