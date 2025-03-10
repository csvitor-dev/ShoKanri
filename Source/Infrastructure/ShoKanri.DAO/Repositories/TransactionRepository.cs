using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories;

public class TransactionRepository(AppDbContext _context) : BaseRepository<Transaction>(_context), ITransactionRepository
{}
