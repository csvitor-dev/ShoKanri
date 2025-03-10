using ShoKanri.Http.Enums;

namespace ShoKanri.Http.Responses.Transaction;

public record TransactionResponse
    (int Id, decimal Amount, TransactionType Type, DateTime CreatedOn, string Description = "");
