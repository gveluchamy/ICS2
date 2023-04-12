using ICSLockers.Data;
using ICSLockers.Models;

namespace ICSLockers.Repository.IRepository
{
    public class AdminRepository: IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tuple<bool, string> AddLocation(LocationModel location)
        {
            bool IsSuccess = false;
            string Result = string.Empty;
            try
            {
                bool IsLocationPresent = _context.Locations.Any(x => x.LocationName.Equals(location.LocationName, StringComparison.OrdinalIgnoreCase));
                if (!IsLocationPresent) {
                    _context.Locations.Add(location);
                    _context.SaveChanges();
                }
                else
                {
                    IsSuccess = false;
                    Result = $"The Location {location.LocationName} is already present. Please rename the location!";
                }
            }
            catch (Exception)
            {
                IsSuccess = false;
                Result = $"Some error has occurred in creating location. Please try again later!";
            }
            return new Tuple<bool, string>(IsSuccess, Result);
        }

        public List<LocationModel> GetAllLocations()
        {
            List<LocationModel> locations = _context.Locations.Where(x => !x.IsDeleted).OrderBy(x=> x.LocationId).ToList();
            return locations;
        }
    }
}
