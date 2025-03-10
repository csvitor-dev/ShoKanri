namespace ShoKanri.Http.Requests.Account;
    public record UpdateAccountRequest(int Id, int UserId, string Name, decimal Balance, string Description);
