using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ICSLockers.Models
{
    [Table("LockerDetails")]
    public class LockerDetailsModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sno { get; set; }

        public int LockerId { get; set; }

        [Display(Name = "LockerUnit")]
        public int LockerUnitId { get; set; }

        [ForeignKey("LockerUnitId")]
        public virtual LockerUnits LockerUnits { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string Item1 { get; set; } = string.Empty;
        public string Item2 { get; set; } = string.Empty;
        public string Item3 { get; set; } = string.Empty;
        public string Item4 { get; set; } = string.Empty;
        public virtual bool IsLockerAvailable
        {
            get
            {
                return string.IsNullOrEmpty(Item1) && string.IsNullOrEmpty(Item2) && string.IsNullOrEmpty(Item3) && string.IsNullOrEmpty(Item4);
            }
        }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public string? ModifiedBy { get; set;}
        public DateTime ModifiedOn { get; set;}
        public bool IsDeleted { get; set;}
    }
}
