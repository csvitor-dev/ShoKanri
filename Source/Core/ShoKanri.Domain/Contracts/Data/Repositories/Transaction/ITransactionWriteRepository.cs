using ShoKanri.Domain.Contracts.Data.Repositories.Base;

namespace ShoKanri.Domain.Contracts.Data.Repositories.Transaction;

public interface ITransactionWriteRepository
    : IWriteOnlyRepository<Entities.Transactions.Transaction>;