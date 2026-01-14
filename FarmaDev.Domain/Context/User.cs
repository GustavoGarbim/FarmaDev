using FarmaDev.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaDev.Domain.Context
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Pharmacy")]
        public int PharmacyId { get; set; }

        public virtual Pharmacy Pharmacy { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsEmailConfirmed { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public UserEnum Role { get; set; }

        public User(int pharmacyId, string username, string email, string password, bool isActive, bool isEmailConfirmed, UserEnum role)
        {
            PharmacyId = pharmacyId;
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
