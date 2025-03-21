using System.Net.Http.Headers;

namespace ShoKanri.Http.Requests.Transaction.Transference;
    public record UpdateTransferenceRequest(decimal Amount, string Description);
