namespace FarmaDev.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(string username, string email, string password);
        Task<bool> UserExists(string username);
        Task<bool> EmailExists(string email);
    }
}
