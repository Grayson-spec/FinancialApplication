using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string CustomerName { get; set; }

        [Required]
        [StringLength(255)]
        public required string Address { get; set; }

        [Required]
        [StringLength(50)]
        public required string ContactInformation { get; set; }
    }
}