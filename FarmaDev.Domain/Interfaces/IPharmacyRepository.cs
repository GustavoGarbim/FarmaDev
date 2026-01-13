using FarmaDev.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaDev.Domain.Interfaces
{
    public interface IPharmacyRepository
    {
        Task CreatePharma (Pharmacy pharmacy);
        Task<Pharmacy?> GetPharmaById (int id);
        Task<List<Pharmacy>> GetAllPharmacies();
        Task DeletePharmacy(int id);
        Task<bool> Commit();
    }
}
