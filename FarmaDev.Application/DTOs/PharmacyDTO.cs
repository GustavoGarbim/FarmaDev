namespace FarmaDev.Application.DTOs
{
    public class PharmacyDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public class PharmacyRegisterUserDTO
    {
        public int PharmacyId { get; set; }
        public int UserId { get; set; }
    }
}
