namespace ShoKanri.Http.Requests.Transaction;

public record RegisterTransactionRequest
    (int UserId, int AccountId, decimal Amount, string Description);
