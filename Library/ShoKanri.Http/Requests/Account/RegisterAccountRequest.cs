namespace ShoKanri.Http.Requests.Account;

public record RegisterAccountRequest
    (int UserId, decimal InitialBalance, bool IgnoreInOverview, string Name, string Description);
