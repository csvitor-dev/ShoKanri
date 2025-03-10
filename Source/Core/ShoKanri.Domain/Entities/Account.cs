using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.Domain.Entities;

public sealed class Account
    (int id, int userId, string name, decimal balance = 0.0m) : BaseEntity(id)
{
    private readonly IList<Transaction> _statement = [];

    public int UserId { get; init; } = userId;
    public string Name { get; private set; } = name;
    public decimal Balance { get; private set; } = balance;
    public string Description { get; private set; } = string.Empty;
    public DateTimeOffset UpdatedOn { get; private set; }  = DateTimeOffset.Now;
    public bool Active { get; private set; } = true;

    public Transaction[] Statement => [.. _statement];

    public void Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
            throw new InvalidOperationException("Amount must be valid value");
        Balance -= amount;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Amount must be greater than 0");
        Balance += amount;
    }

    public void RegisterTransaction(Transaction transaction)
        => _statement.Add(transaction);

    public Transaction? GetTransaction(int transactionId)
        => _statement.SingleOrDefault(transaction => transaction.Id == transactionId);
}
