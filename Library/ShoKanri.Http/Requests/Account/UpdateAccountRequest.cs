namespace ShoKanri.Http.Requests.Account;

public record UpdateAccountRequest(string? Name, decimal? Balance, string? Description);
