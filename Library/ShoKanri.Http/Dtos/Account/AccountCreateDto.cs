namespace ShoKanri.Http.Dtos.Account;

public class AccountCreateDto
{
    public string Name { get; set; }
    public decimal InitialBalance { get; set; }
    public string? Description { get; set; }
    public bool IgnoreInOverview { get; set; }
}
