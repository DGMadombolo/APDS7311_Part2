using System.ComponentModel.DataAnnotations;

namespace APDS7311_Part2.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Payment> Payments { get; set; }
    }
}