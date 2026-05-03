using Microsoft.AspNetCore.Mvc;
using APDS7311_Part2.Data;
using APDS7311_Part2.Models;
using APDS7311_Part2.DTOs;
using System.Text.RegularExpressions;

namespace APDS7311_Part2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ REGISTER
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Regex validation (extra security)
            if (!Regex.IsMatch(dto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return BadRequest("Invalid email format");

            if (_context.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Email already exists");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "User registered successfully" });
        }

        // ✅ LOGIN
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid email or password");

            return Ok(new
            {
                message = "Login successful",
                userId = user.Id
            });
        }
    }
}