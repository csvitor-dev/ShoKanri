namespace ShoKanri.Http.Dtos.Transaction;

public class TransactionCreateDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int TransactionType { get; set; } // 0=Income, 1=Expense, 2=Transfer
}
