namespace ICSLockers.Models
{
    public class UserReportsModel
    {
        public List<UserEvent>? UserEvents { get; set; }
        public List<ApplicationUser>? Users { get; set; }
        public List<LockerUnitModel>? Lockers { get; set; }
        public List<LocationModel>? Location { get; set; }
    }
}
