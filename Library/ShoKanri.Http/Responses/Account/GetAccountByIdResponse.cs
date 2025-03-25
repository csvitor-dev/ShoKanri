namespace ShoKanri.Http.Responses.Account;
public record GetAccountByIdResponse(int Id, int UserId, string Name, decimal Balance, string Description);
