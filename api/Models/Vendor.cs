using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string VendorName { get; set; }

        [Required]
        [StringLength(255)]
        public required string Address { get; set; }

        [Required]
        [StringLength(50)]
        public required string ContactInformation { get; set; }
    }
}