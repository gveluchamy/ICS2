using ICSLockers.Models;

namespace ICSLockers.Repository.IRepository
{
    public interface IAdminRepository
    {
        List<LocationModel> GetAllLocations();
        LocationModel? GetLocationDetails(int locationId);
        DivisionModel? GeDivisionDetails(int divionId);
        Tuple<bool, string> AddLocation(LocationModel location);
        bool AddDivisionsByLocation(LocationModel location);
        Tuple<bool, string> UpdateDivisionByDivisionID(DivisionModel division);
        Tuple<bool,string > UpdateLockerByDivisionId (LockerUnitModel lockerUnit);
        List<DivisionModel> GetDivisionByLocationId(int locationId);
        List<LockerUnitModel> GetLockerUnitsByDivisionId(int divisionId);
        AdminDashboard GetDashBoardDetails();
        List<UserEvent> GetUserEventdetails();
        List<ApplicationUser> GetAllUsers();
        UserReportsModel UserReport();
    }
}
