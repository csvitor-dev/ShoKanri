namespace ShoKanri.Http.Responses.Transaction;

public class TransactionResponse
{
        public int Id { get; set; }
	    public decimal Amount { get; set; }
	    public string Description { get; set; }
	    public TransactionType Type { get; set; }
	    public DateTime CreatedOn { get; set; }
    
} 
