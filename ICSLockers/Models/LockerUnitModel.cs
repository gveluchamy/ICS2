using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ICSLockers.Models
{
    [Table("Locker")]
    public class LockerUnitModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LockerId { get; set; }

        [ForeignKey("Division")]
        public int DivisionId { get; set; }
        public string? Barcode { get; set; }
        public string? Item1 { get; set; }
        public string? Item2 { get; set; }
        public string? Item3 { get; set; }
        public string? Item4 { get; set; }
        public string? Item5 { get; set; }
        public virtual bool IsSpaceAvailable
        {
            get
            {
                return string.IsNullOrEmpty(Item1) && string.IsNullOrEmpty(Item2) && string.IsNullOrEmpty(Item3) && string.IsNullOrEmpty(Item4) && string.IsNullOrEmpty(Item5);
            }
        }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        [ForeignKey("DivisionId")]
        public virtual DivisionModel? Division { get; set; }
    }
}

