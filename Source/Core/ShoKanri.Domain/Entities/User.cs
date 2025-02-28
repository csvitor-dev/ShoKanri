namespace ShoKanri.Domain.Entities;

public sealed class User : BaseEntity
{
    private readonly IList<Account> _accounts = new List<Account>();
    
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    
    public Account? GetAccount(int accountId)
        => _accounts.SingleOrDefault(account => account.Id == accountId);
}