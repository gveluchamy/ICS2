using ICSLockers.Models;

namespace ICSLockers.Repository.IRepository
{
    public interface IAdminRepository
    {
        List<LocationModel> GetAllLocations();      
        Tuple<bool, string> AddLocation(LocationModel location);
        Tuple<bool, string> UpdateDivisionByDivisionID(DivisionModel division);
        List<DivisionModel> GetDivisionByLocationId(int locationId);
        List<LockerUnitModel> GetLockerUnitsByDivisionId(int divisionId);
        AdminDashboard GetDashBoardDetails();
    }
}
