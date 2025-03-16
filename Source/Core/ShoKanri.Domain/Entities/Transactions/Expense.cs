namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Expense
: Transaction
{
    //talvez não seja nescessario, ainda vou testar
    private Expense(){}

    public Expense(int id, int accountId, decimal amount) : base(id, accountId, amount){}

    protected override void Transact(Account account)
        => account.Withdraw(Amount);
}