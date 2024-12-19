using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string ItemName { get; set; }

        [Required]
        [StringLength(255)]
        public required string Description { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}