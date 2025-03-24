using ShoKanri.Domain.Contracts.Data.Repositories.Base;

namespace ShoKanri.Domain.Contracts.Data.Repositories.Transaction;

public interface ITransactionReadRepository
    : IReadOnlyRepository<Entities.Transactions.Transaction>;
