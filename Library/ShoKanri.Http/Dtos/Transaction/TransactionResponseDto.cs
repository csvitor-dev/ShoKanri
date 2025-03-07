namespace ShoKanri.Http.Dtos.Transaction;

public class TransactionResponseDto
{
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int TransactionType { get; set; }
    public DateTime CreatedOn { get; set; }
}
