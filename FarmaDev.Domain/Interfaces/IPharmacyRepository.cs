using FarmaDev.Domain.Context;

namespace FarmaDev.Domain.Interfaces
{
    public interface IPharmacyRepository
    {
        Task CreatePharma (Pharmacy pharmacy);
        Task<Pharmacy?> GetPharmaById (int id);
        Task<List<Pharmacy>> GetAllPharmacies();
        Task DeletePharmacy(int id);
        Task RegisterUser(int pharmacy, int user);
        Task<bool> Commit();
    }
}
