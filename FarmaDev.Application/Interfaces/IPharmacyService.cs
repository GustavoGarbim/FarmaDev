using FarmaDev.Application.DTOs;
using FarmaDev.Domain.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
