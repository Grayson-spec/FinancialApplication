using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string PurchaseOrderNumber { get; set; }

        [Required]
        public DateTime PurchaseOrderDate { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}