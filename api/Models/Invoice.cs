using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string InvoiceNumber { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [StringLength(255)]
        public required string CustomerName { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}