
using System.ComponentModel.DataAnnotations;

namespace APDS7311_Part2.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(10)]
        public string Currency { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        // Foreign key
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
