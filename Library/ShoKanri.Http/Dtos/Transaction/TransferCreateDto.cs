namespace ShoKanri.Http.Dtos.Transaction;

public class TransferCreateDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int SourceAccountId { get; set; }
    public int DestinationAccountId { get; set; }
}
