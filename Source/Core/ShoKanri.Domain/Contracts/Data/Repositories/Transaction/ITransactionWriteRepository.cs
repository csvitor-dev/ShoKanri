namespace ShoKanri.Domain.Contracts.Data.Repositories.Transaction;

public interface ITransactionWriteRepository
{
    Task CreateAsync(Entities.Transactions.Transaction entity);
    Task UpdateAsync(Entities.Transactions.Transaction entity);
    Task DeleteAsync(int id);
}