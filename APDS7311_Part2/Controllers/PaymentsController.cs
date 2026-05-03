using APDS7311_Part2.Data;
using APDS7311_Part2.DTOs;
using APDS7311_Part2.DTOs.APDS7311_Part2.DTOs;
using APDS7311_Part2.Models;
using Microsoft.AspNetCore.Mvc;

namespace APDS7311_Part2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ CREATE PAYMENT
        [HttpPost]
        public IActionResult CreatePayment([FromBody] PaymentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var payment = new Payment
            {
                Amount = dto.Amount,
                Currency = dto.Currency,
                UserId = dto.UserId
            };

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return Ok(payment);
        }

        // ✅ GET PAYMENTS BY USER
        [HttpGet("{userId}")]
        public IActionResult GetPayments(int userId)
        {
            var payments = _context.Payments
                .Where(p => p.UserId == userId)
                .ToList();

            return Ok(payments);
        }
    }
}