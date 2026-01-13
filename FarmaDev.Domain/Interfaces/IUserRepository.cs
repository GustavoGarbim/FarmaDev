using FarmaDev.Domain.Context;

namespace FarmaDev.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<List<User>> GetAllUsers();
        Task DeleteUser(int id);
        Task<bool> Commit();
    }
}
