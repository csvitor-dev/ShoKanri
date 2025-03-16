namespace ShoKanri.Domain.Entities;

public sealed class User
: BaseEntity
{
    private readonly IList<Account> _accounts = [];

    private User() {}
    public User(int id, string name, string email, string password) : base(id)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }
    public DateTimeOffset UpdatedOn { get; private set; } = DateTimeOffset.Now.UtcDateTime;
    public bool Active { get; private set; } = true;

    public Account? GetAccount(int accountId)
        => _accounts.SingleOrDefault(account => account.Id == accountId);

    public void LinkAccount(Account account)
    {
        if (_accounts.Count == 4)
            throw new InvalidOperationException($"Account limit exceeded (an user must have exactly 4 accounts).");
        _accounts.Add(account);
    }
}