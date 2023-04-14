namespace ICSLockers.Models
{
    public class UserEvent
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public UserEventType EventType { get; set; }
        public DateTime EventTime { get; set; }
    }

    // define the UserEventType enumeration
    public enum UserEventType
    {
        Login,
        Logout
    }
}
