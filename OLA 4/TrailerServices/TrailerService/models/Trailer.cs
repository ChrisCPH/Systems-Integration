using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailerService.Models
{
    public class TrailerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrailerID { get; set; }
        public required string Location { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}