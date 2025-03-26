namespace ShoKanri.Http.Requests.Transaction;

public record UpdateTransactionRequest
    (int UserId, int AccountId, decimal Amount, string Description);
