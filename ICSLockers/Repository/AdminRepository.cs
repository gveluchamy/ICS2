using ICSLockers.Data;
using ICSLockers.Models;

namespace ICSLockers.Repository.IRepository
{
    public class AdminRepository : IAdminRepository
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
                bool IsLocationPresent = _context.Locations.ToList().Any(x => x.LocationName.Equals(location.LocationName, StringComparison.OrdinalIgnoreCase));
                if (!IsLocationPresent)
                {
                    var test = _context.Locations.Add(location);
                    _context.SaveChanges();

                    if (location.TotalDivision > 0)
                    {
                        for (int i = 1; i <= location.TotalDivision; i++)
                        {
                            DivisionModel division = new()
                            {
                                LocationId = location.LocationId,
                                CreatedBy = location.CreatedBy,
                                ModifiedBy = location.ModifiedBy,
                                CreatedOn = DateTime.Now,
                                ModifiedOn = DateTime.Now,
                            };
                            AddNewDivision(division);
                        }
                    }
                    IsSuccess = true;
                    Result = $"The location {location.LocationName} has been added succesfully with {location.TotalDivision} divisions!";
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
            List<LocationModel> locations = _context.Locations.Where(x => !x.IsDeleted).OrderBy(x => x.LocationId).ToList();
            return locations;
        }

        public List<DivisionModel> GetDivisionByLocationId(int locationId)
        {
            List<DivisionModel> divisionList = _context.Divisions.Where(x => x.LocationId == locationId).ToList();
            return divisionList;
        }

        public bool AddNewDivision(DivisionModel division)
        {
            try
            {
                _context.Divisions.Add(division);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
