using System.ComponentModel.DataAnnotations;

namespace APDS7311_Part2.DTOs
{
    public class PaymentDto
    {
        [Required]
        [Range(1, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}