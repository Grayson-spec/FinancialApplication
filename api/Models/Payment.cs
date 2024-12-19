using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [StringLength(50)]
        public required string PaymentMethod { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required]
        public int InvoiceId { get; set; }
    }
}