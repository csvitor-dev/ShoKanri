using ShoKanri.Http.Enums;

namespace ShoKanri.Http.Requests.Transaction;

public record RegisterTransactionRequest(decimal Amount, TransactionType Type, string Description = "");
