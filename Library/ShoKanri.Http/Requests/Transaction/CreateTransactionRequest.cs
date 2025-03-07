using ShoKanri.Http.Enums;

namespace ShoKanri.Http.Requests.Transaction;

public class CreateTransactionRequest
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public TransactionType TransactionType { get; set; }
}
