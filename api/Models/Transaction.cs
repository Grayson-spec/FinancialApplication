using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [StringLength(255)]
        public required string Description { get; set; }

        [Required]
        public decimal DebitAmount { get; set; }

        [Required]
        public decimal CreditAmount { get; set; }

        [Required]
        public int AccountId { get; set; }
    }
}