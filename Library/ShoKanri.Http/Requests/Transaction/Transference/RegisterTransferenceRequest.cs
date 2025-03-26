namespace ShoKanri.Http.Requests.Transaction.Transference;

public record RegisterTransferenceRequest
    (int UserId, int SourceId, int DestinationId, decimal Amount, string Description);
