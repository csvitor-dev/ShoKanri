namespace ShoKanri.Domain.Contracts.Data.Repositories.Transaction;

public interface ITransactionReadRepository
{
    Task<Entities.Transactions.Transaction> FindAllAsync();
    Task<Entities.Transactions.Transaction> FindByIdAsync(int id);
}