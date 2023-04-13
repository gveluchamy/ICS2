using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSLockers.Models
{
    [Table("Division")]
    public class DivisionModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DivisionId { get; set; }
        public int DivisionNo { get; set; }
        [Required]
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public int TotalLockers { get; set; }
        public string? IpAddress { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        [ForeignKey("LocationId")]
        public virtual LocationModel? Location { get; set; }

    }
}
