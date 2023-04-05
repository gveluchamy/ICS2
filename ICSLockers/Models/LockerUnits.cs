using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ICSLockers.Models
{
    public class LockerUnits
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LockerId { get; set; }
        public int LockerUnitNo { get; set; }
        public int TotalLocker { get; set; }
        public int UsedLocker { get; set; }
        public virtual int AvailableLocker
        {
            get
            {
                return TotalLocker - UsedLocker;
            }
        }
        public virtual bool IsLockerAvailable
        {
            get
            {
                return TotalLocker - AvailableLocker != 0;
            }
        }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
