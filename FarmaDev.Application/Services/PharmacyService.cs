using FarmaDev.Application.DTOs;
using FarmaDev.Application.Interfaces;
using FarmaDev.Domain.Context;
using FarmaDev.Domain.Interfaces;
using FarmaDev.Infraestructure.ExternalServices;

namespace FarmaDev.Application.Services
{
    public class PharmacyService : IPharmacyService
    {
        public readonly IPharmacyRepository _pharmacyRepository;
        private readonly IEmailSender _emailSender;

        public PharmacyService(IPharmacyRepository pharmacyRepository, IEmailSender emailSender)
        {
            _pharmacyRepository = pharmacyRepository;
            _emailSender = emailSender;
        }

        public async Task<Pharmacy> CreatePharmacy(PharmacyDTO dto)
        {
            var pharmacy = new Pharmacy(dto.Name, dto.Email, dto.Number, dto.Address, dto.City, dto.State, dto.PostalCode, true);

            await _emailSender.SendEmailRegisterPharmacy(pharmacy.Email, pharmacy.Name);

            await _pharmacyRepository.CreatePharma(pharmacy);
            await _pharmacyRepository.Commit();
            return pharmacy;
        }

        public async Task RegisterUser(PharmacyRegisterUserDTO dto)
        {
            await _pharmacyRepository.RegisterUser(dto.PharmacyId, dto.UserId);
            await _pharmacyRepository.Commit();
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
