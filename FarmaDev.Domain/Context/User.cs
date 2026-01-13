using FarmaDev.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FarmaDev.Domain.Context
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsEmailConfirmed { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public UserEnum Role { get; set; }

        public User(string username, string email, string password, bool isActive, bool isEmailConfirmed, UserEnum role)
        {
            Username = username;
            Email = email;
            Password = password;
            IsActive = isActive;
            IsEmailConfirmed = isEmailConfirmed;
            CreatedAt = DateTime.UtcNow.ToLocalTime();
            Role = role;
        }
    }
}
