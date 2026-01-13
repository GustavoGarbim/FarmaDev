using System.ComponentModel.DataAnnotations;

namespace FarmaDev.Domain.Context
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        public Pharmacy(string name, string email, string number, string address, string city, string state, string postalCode, bool isActive, DateTime createdAt)
        {
            Name = name;
            Email = email;
            Number = number;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            IsActive = isActive;
            CreatedAt = DateTime.UtcNow.ToLocalTime();
        }
    }
}
