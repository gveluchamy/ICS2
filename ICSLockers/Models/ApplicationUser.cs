using Microsoft.AspNetCore.Identity;

namespace ICSLockers.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SSN { get; set; }
        public string PasswordEnc { get; set; }
        public int LockerUnit { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool CheckOutStatus { get; set; }
    }
}
