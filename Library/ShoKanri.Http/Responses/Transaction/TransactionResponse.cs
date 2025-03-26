namespace ShoKanri.Http.Responses.Transaction;

public record TransactionResponse
    (int Id, decimal Amount, DateTime CreatedOn, string Description);
