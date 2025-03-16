using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.Domain.Entities;

public sealed class Account
: BaseEntity
{
    private readonly IList<Transaction> _statement = [];

    private Account(){}

    public Account(int id, int userId, string name, decimal balance = 0.0m) : base(id)
    {
        UserId = userId;
        Name = name;
        Balance = balance;
    }

    public int UserId { get; init; }
    public string? Name { get; private set; }
    public decimal Balance { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public DateTimeOffset UpdatedOn { get; private set; }  = DateTimeOffset.Now.UtcDateTime;
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
