using FarmaDev.Application.DTOs;
using FarmaDev.Application.Interfaces;
using FarmaDev.Domain.Context;
using FarmaDev.Domain.Enums;
using FarmaDev.Domain.Interfaces;

namespace FarmaDev.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(UserDTO dto)
        {
            var cnf = await _userRepository.GetUserByEmail(dto.Email);
            if (cnf != null)
            {
                throw new Exception("Email já cadastrado");
            }

            var user = new User(dto.Username, dto.Email, dto.Password, dto.IsActive, false, UserEnum.Owner);
            // Por enquanto todos os usuários criados são do tipo Owner
            await _userRepository.CreateUser(user);
            await _userRepository.Commit();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
            await _userRepository.Commit();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            return user;
        }

        public async Task UpdateUser(User user)
        {
            var cnf = await _userRepository.GetUserById(user.Id);
            if (cnf == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            await _userRepository.UpdateUser(user);
            await _userRepository.Commit();
        }
    }
}
