namespace ShoKanri.Http.Requests.Transaction;

public class CreateTransferRequest
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int SourceAccountId { get; set; }
    public int DestinationAccountId { get; set; }
}
