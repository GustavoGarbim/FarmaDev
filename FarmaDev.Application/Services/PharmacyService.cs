using FarmaDev.Application.DTOs;
using FarmaDev.Application.Interfaces;
using FarmaDev.Domain.Context;
using FarmaDev.Domain.Interfaces;
using FarmaDev.Infraestructure.Data;

namespace FarmaDev.Application.Services
{
    public class PharmacyService : IPharmacyService
    {
        public readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public async Task<Pharmacy> CreatePharmacy(PharmacyDTO dto)
        {
            var pharmacy = new Pharmacy(dto.Name, dto.Email, dto.Number, dto.Address, dto.City, dto.State, dto.PostalCode, true);

            await _pharmacyRepository.CreatePharma(pharmacy);
            await _pharmacyRepository.Commit();
            return pharmacy;
        }

        public async Task<Pharmacy?> GetPharmacyById(int id)
        {
            return await _pharmacyRepository.GetPharmaById(id);
        }

        public async Task<List<Pharmacy>> ListPharmacys()
        {
            return await _pharmacyRepository.GetAllPharmacies(); 
        }

        public async Task<bool> DeletePharmacy(int id)
        {
            await _pharmacyRepository.DeletePharmacy(id);
            return await _pharmacyRepository.Commit();
        }
    }
}
