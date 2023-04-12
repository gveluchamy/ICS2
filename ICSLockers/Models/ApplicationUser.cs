using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICSLockers.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public virtual string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Required]
        public int SSN { get; set; }
        [Required]
        public string? PasswordEnc { get; set; }
        [Required]       
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public int LockerUnitId { get; set; }
        public int LockerDetailId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public bool CheckOutStatus { get; set; }
      
    }
}
