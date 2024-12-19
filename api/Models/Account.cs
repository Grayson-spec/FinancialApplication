using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string AccountNumber { get; set; }

        [Required]
        [StringLength(255)]
        public required string AccountName { get; set; }

        [Required]
        [StringLength(50)]
        public required string AccountType { get; set; }
    }
}