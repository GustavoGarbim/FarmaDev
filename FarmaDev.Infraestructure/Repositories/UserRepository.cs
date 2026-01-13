using FarmaDev.Domain.Context;
using FarmaDev.Domain.Interfaces;
using FarmaDev.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmaDev.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FarmaDevDbContext _context;

        public UserRepository(FarmaDevDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await Task.FromResult(_context.Users.ToList());
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                _context.Users.Update(user);
            }
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
