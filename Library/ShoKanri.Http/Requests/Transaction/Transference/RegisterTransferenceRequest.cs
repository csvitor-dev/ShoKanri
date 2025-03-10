using ShoKanri.Http.Enums;

namespace ShoKanri.Http.Requests.Transaction.Transference;

public record RegisterTransferenceRequest(
    int SourceId,
    int DestinationId,
    decimal Amount,
    TransactionType Type,
    string Description = "")
    : RegisterTransactionRequest(Amount, Type, Description);
