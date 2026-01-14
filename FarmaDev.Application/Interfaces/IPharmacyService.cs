using FarmaDev.Application.DTOs;
using FarmaDev.Domain.Context;

namespace FarmaDev.Application.Interfaces
{
    public interface IPharmacyService
    {
        Task<Pharmacy> CreatePharmacy(PharmacyDTO dto);
        Task<List<Pharmacy>> ListPharmacys();
        Task<Pharmacy?> GetPharmacyById(int id); 
        Task<bool> DeletePharmacy(int id);
    }
}
