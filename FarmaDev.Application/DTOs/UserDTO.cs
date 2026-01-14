using FarmaDev.Domain.Context;
using FarmaDev.Domain.Enums;

namespace FarmaDev.Application.DTOs
{
    public class UserDTO
    {
        public int PharmacyId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
