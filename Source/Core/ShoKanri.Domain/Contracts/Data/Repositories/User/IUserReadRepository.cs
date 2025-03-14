namespace ShoKanri.Domain.Contracts.Data.Repositories.User;

public interface IUserReadRepository
{
    Task<Entities.User?> FindByIdAsync(int id);
    Task<bool> FindActiveEmailAsync(string email);
}