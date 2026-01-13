using FarmaDev.Application.DTOs;
using FarmaDev.Application.Interfaces;
using FarmaDev.Domain.Context;
using Microsoft.AspNetCore.Mvc;

namespace FarmaDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO dto)
        {
            var result = await _userService.CreateUser(dto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Users could not be created, try again later.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Users not found, try again later.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok("Users deleted successfully.");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO dto)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("Users not found, try again later.");
            }
            user.Username = dto.Username;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.IsActive = dto.IsActive;
            await _userService.UpdateUser(user);
            return Ok("Users updated successfully!");
        }
    }
}