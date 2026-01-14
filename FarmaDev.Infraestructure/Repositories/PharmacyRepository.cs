using FarmaDev.Domain.Context;
using FarmaDev.Domain.Interfaces;
using FarmaDev.Infraestructure.Data;

namespace FarmaDev.Infraestructure.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly FarmaDevDbContext _context;

        public PharmacyRepository(FarmaDevDbContext context)
        {
            _context = context;
        }

        public async Task CreatePharma(Pharmacy pharmacy)
        {
            await _context.Pharmacy.AddAsync(pharmacy);                                                                                                                                                                                                                                                             
        }

        public async Task<Pharmacy?> GetPharmaById(int id)
        {
            return await _context.Pharmacy.FindAsync(id);
        }

        public async Task<List<Pharmacy>> GetAllPharmacies()
        {
            return await Task.FromResult(_context.Pharmacy.ToList());
        }

        public async Task DeletePharmacy(int id)
        {
            var pharmacy = await GetPharmaById(id);
            if (pharmacy != null)
            {
                _context.Pharmacy.Remove(pharmacy);
            }
        }

        public async Task RegisterUser(int pharmacyId, int userId)
        {
            var pharmacy = await GetPharmaById(pharmacyId);
            if (pharmacy != null)
            {
                var user = await _context.Users.FindAsync(userId);
                if (user != null)
                {
                    user.PharmacyId = pharmacyId;
                }
            }
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
