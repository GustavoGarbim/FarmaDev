using FarmaDev.Application.DTOs;
using FarmaDev.Domain.Context;

namespace FarmaDev.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(UserDTO dto);
        Task UpdateUser(User user);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<List<User>> GetAllUsers();
        Task DeleteUser(int id);
    }
}
