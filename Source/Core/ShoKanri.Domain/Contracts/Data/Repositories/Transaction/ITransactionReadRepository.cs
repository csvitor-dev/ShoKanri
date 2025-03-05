namespace ShoKanri.Domain.Contracts.Data.Repositories.Transaction;

public interface ITransactionReadRepository
{
    Task<List<Entities.Transactions.Transaction>> FindAllAsync();
    Task<Entities.Transactions.Transaction?> FindByIdAsync(int id);
}