namespace ShoKanri.Http.Requests.Transaction;

public class CreateTransferenceRequest
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int SourceId { get; set; }
    public int DestinationId { get; set; }
}
