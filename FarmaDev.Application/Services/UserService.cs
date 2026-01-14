using FarmaDev.Application.DTOs;
using FarmaDev.Application.Interfaces;
using FarmaDev.Domain.Context;
using FarmaDev.Domain.Enums;
using FarmaDev.Domain.Interfaces;
using FarmaDev.Infraestructure.ExternalServices;

namespace FarmaDev.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        private readonly IPharmacyRepository _pharmacyRepository;

        public UserService(IUserRepository userRepository, IEmailSender emailSender, IPharmacyRepository pharmacyRepository)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
            _pharmacyRepository = pharmacyRepository;
        }

        public async Task<User> CreateUser(UserDTO dto)
        {
            var cnf = await _userRepository.GetUserByEmail(dto.Email);
            if (cnf != null)
            {
                throw new Exception("Email already registered. Try another email.");
            }
            var user = new User(dto.PharmacyId ,dto.Username, dto.Email, dto.Password, dto.IsActive, false, UserEnum.Owner);
            var empId = user.PharmacyId;
            try
            {
                var pharmacy = await _pharmacyRepository.GetPharmaById(empId);
                await _emailSender.SendEmailRegister(user.Email, user.Username, pharmacy.Name);
            }
            catch{throw new Exception("User Pharmacy not found, try again later.");}
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
