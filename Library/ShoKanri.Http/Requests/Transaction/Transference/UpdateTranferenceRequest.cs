namespace ShoKanri.Http.Requests.Transaction.Transference;

public record UpdateTransferenceRequest
    (int UserId, int SourceId, int DestinationId, decimal Amount, string Description);
