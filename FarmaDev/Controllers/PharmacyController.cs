using FarmaDev.Application.DTOs;
using FarmaDev.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FarmaDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;
        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePharmacy([FromBody] PharmacyDTO dto)
        {
            var result = await _pharmacyService.CreatePharmacy(dto);
            if (result != null)
            {
                return Ok(dto);
            }
            return BadRequest("Pharmacy could not be created, try again later.");
        }

        [HttpPost("register-user")]
        public async Task RegisterUser([FromBody] PharmacyRegisterUserDTO dto)
        {
            await _pharmacyService.RegisterUser(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPharmacyById(int id)
        {
            var result = await _pharmacyService.GetPharmacyById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Pharmacy not found, try again later.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPharmacies()
        {
            var result = await _pharmacyService.ListPharmacys();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacy(int id)
        {
            var result = await _pharmacyService.DeletePharmacy(id);
            if (result)
            {
                return Ok("Pharmacy deleted successfully.");
            }
            return BadRequest("Pharmacy could not be deleted, try again later.");
        }
    }
}
