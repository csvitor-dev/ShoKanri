namespace ShoKanri.Http.Requests.Account;

public class CreateAccountRequest
{
    public string Name { get; set; }
    public decimal InitialBalance { get; set; }
    public string? Description { get; set; }
    public bool IgnoreInOverview { get; set; }
}
