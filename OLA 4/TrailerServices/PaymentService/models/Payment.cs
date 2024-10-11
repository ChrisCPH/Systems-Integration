using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailerMonolith.Models
{
    public class PaymentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }
        public int RentalID { get; set; }
        public decimal InsuranceFee { get; set; } = 50m;
        public decimal LateFee { get; set; } = 25m;
    }
}