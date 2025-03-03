namespace ShoKanri.Domain.Entities;

public sealed class User
    (int id, string name, string email, string password) : BaseEntity(id)
{
    private readonly IList<Account> _accounts = new List<Account>();
    
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    
    public Account? GetAccount(int accountId)
        => _accounts.SingleOrDefault(account => account.Id == accountId);

    public void LinkAccount(Account account)
    {
        if (_accounts.Count == 4)
            throw new InvalidOperationException($"Account limit exceeded (an user must have exactly 4 accounts).");
        _accounts.Add(account);
    }
}