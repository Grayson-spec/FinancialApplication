using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class SalesOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string SalesOrderNumber { get; set; }

        [Required]
        public DateTime SalesOrderDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}