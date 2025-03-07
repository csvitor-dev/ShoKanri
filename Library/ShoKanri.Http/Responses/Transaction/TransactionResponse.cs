namespace ShoKanri.Http.Responses.Transaction;

public class TransactionResponse
{
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int TransactionType { get; set; }
    public DateTime CreatedOn { get; set; }
}
