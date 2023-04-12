using ICSLockers.Models;

namespace ICSLockers.Repository.IRepository
{
    public interface IAdminRepository
    {
        List<LocationModel> GetAllLocations();
        Tuple<bool, string> AddLocation(LocationModel location);
        List<DivisionModel> GetDivisionByLocationId(int locationId);
    }
}
