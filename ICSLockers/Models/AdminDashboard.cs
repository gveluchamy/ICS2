namespace ICSLockers.Models
{
    public class AdminDashboard
    {
        public int TotalLocation { get; set; }
        public int TotalDivisions { get; set; }
        public int TotalLockers { get; set; }
        public int LockerUsed { get; set; }
        public virtual int AvailableLockers
        {
            get
            {
                return TotalLockers - LockerUsed;
            }
        }
        public List<ApplicationUser>? UserList { get; set; }
    }
}