using ShoKanri.Domain.Contracts.Data.Repositories.Base;

namespace ShoKanri.Domain.Contracts.Data.Repositories.User;

public interface IUserWriteRepository : IWriteOnlyRepository<Entities.User>;
