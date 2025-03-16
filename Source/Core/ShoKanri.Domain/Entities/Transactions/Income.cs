namespace ShoKanri.Domain.Entities.Transactions;

public sealed class Income
: Transaction
{
    //talvez não seja nescessario, ainda vou testar
    private Income(){}

    public Income(int id, int accountId, decimal amount) : base(id, accountId, amount){}

    protected override void Transact(Account account)
        => account.Deposit(Amount);
}