using ShoKanri.Domain.Contracts.Data.Repositories.Base;

namespace ShoKanri.Domain.Contracts.Data.Repositories;

public interface ITransactionRepository 
    : IWriteOnlyRepository<Entities.Transactions.Transaction>, IReadOnlyRepository<Entities.Transactions.Transaction>;