namespace ShoKanri.Domain.Entities;

public sealed class User : BaseEntity
{
    private readonly IList<Account> _accounts = [];

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.Now.UtcDateTime;
    public bool Active { get; set; } = true;

    public Account? GetAccount(int accountId)
        => _accounts.SingleOrDefault(account => account.Id == accountId);

    public void LinkAccount(Account account)
    {
        if (_accounts.Count == 4)
            throw new InvalidOperationException($"Account limit exceeded (an user must have exactly 4 accounts).");
        _accounts.Add(account);
    }
}