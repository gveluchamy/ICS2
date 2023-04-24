using ICSLockers.Data;
using ICSLockers.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ICSLockers.Repository.IRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly int DefaultLockersList = 5;

        public AdminRepository(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public Tuple<bool, string> AddLocation(LocationModel location)
        {
            bool IsSuccess = false;
            string Result = string.Empty;
            try
            {
                var locationName=location.LocationName;
                bool IsLocationPresent = _context.Locations.ToList().Any(x => x.LocationName.Equals(location.LocationName, StringComparison.OrdinalIgnoreCase));
                if (!IsLocationPresent)
                {
                    if (!string.IsNullOrEmpty(locationName))
                    {
                        _context.Locations.Add(location);
                        _context.SaveChanges();

                        List<DivisionModel> divisionList = _context.Divisions.Where(x => x.LocationId == location.LocationId).ToList();

                        int totalDivision = divisionList.Count + location.TotalDivision;
                        int divisionIdStart = divisionList.Count + 1;

                        AddNewDivision(totalDivision, divisionIdStart, location);
                        
                        IsSuccess = true;
                        Result = $"The location {location.LocationName} has been added succesfully with {location.TotalDivision} divisions!";
                    }
                    else
                    {
                        IsSuccess = false;
                        Result = $"Please Enter the Location Name!";
                    }
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

        private void AddNewDivision(int totalDivision, int divisionIdStart, LocationModel location)
        {
           
            try { 
                for (int i = divisionIdStart; i <= totalDivision; i++)
                {
                    DivisionModel division = new()
                    {
                        DivisionNo = i,
                        TotalLockers = DefaultLockersList,
                        LocationId = location.LocationId,
                        CreatedBy = location.CreatedBy,
                        ModifiedBy = location.ModifiedBy,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                    };
                    if (division.DivisionNo <= 10)
                    {
                        _context.Divisions.Add(division);
                        _context.SaveChanges();

                        List<LockerUnitModel> lockersList = _context.LockerUnits.Where(x => x.DivisionId == division.DivisionId).ToList();

                        int totalLockers = lockersList.Count + division.TotalLockers;
                        int lockerIdStart = lockersList.Count + 1;

                        AddNewLockers(totalLockers, lockerIdStart, division);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AddNewLockers(int totalLockers, int lockerIdStart, DivisionModel division)
        {
           try
            {
                for (int i = lockerIdStart; i <= totalLockers; i++)
                {
                        LockerUnitModel lockerUnit = new()
                    {
                        DivisionId = division.DivisionId,
                        CreatedBy = division.CreatedBy,
                        ModifiedBy = division.ModifiedBy,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                    };
                    _context.LockerUnits.Add(lockerUnit);
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public List<LocationModel> GetAllLocations()
        {
            List<LocationModel> locations = _context.Locations.Where(x => !x.IsDeleted).OrderBy(x => x.LocationId).ToList();
            return locations;
        }
            
        public List<DivisionModel> GetDivisionByLocationId(int locationId)
        {
            List<DivisionModel> divisionList = _context.Divisions
                .Include(d => d.Location)
                .Where(x => x.LocationId == locationId)
                .ToList();
            return divisionList;
        }

        public Tuple<bool, string> UpdateDivisionByDivisionID(DivisionModel division)
        {
            bool IsSuccess = false;
            string Result = string.Empty;

            if (division != null && division.DivisionId != null)
            {
                try
                {
                    var Division = _context.Divisions.FirstOrDefault(d => d.DivisionId == division.DivisionId);

                    if (Division != null)
                    {
                        // Update the properties of the existing entity
                        Division.DivisionNo = division.DivisionNo;
                        Division.LocationId = division.LocationId;
                        Division.TotalLockers = Division.TotalLockers + division.TotalLockers;
                        Division.ModifiedBy = division.ModifiedBy;
                        Division.ModifiedOn = DateTime.Now;

                        _context.SaveChanges();

                        List<LockerUnitModel> lockersList = _context.LockerUnits.Where(x => x.DivisionId == division.DivisionId).ToList();

                        int totalLockers = lockersList.Count + division.TotalLockers;
                        int lockerIdStart = lockersList.Count + 1;

                        AddNewLockers(totalLockers, lockerIdStart, division);

                        IsSuccess = true;
                    }
                    else
                    {
                        Result = "Division not found";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Result = "Invalid division ID";
            }

            return new Tuple<bool, string>(IsSuccess, Result);
        }

        public List<LockerUnitModel> GetLockerUnitsByDivisionId(int divisionId)
        {
            List<LockerUnitModel> lockerUnits = _context.LockerUnits
                .Include(d => d.Division)
                .ThenInclude(x=> x.Location)
                .Where(x => x.DivisionId == divisionId).ToList();
            return lockerUnits;
        }

        public Tuple<bool, string> UpdateLockerByDivisionId(LockerUnitModel lockerunit)
        {
            bool IsSuccess = false;
            string Result = string.Empty;
            if (lockerunit != null)
            {
                _context.LockerUnits.Add(lockerunit);
                _context.SaveChanges();
            }
            return new Tuple<bool, string>(IsSuccess, Result);
        }

        public AdminDashboard GetDashBoardDetails()
        {
            AdminDashboard dashboard = new()
            {
                TotalLocation = _context.Locations.Count(),
                TotalDivisions = _context.Divisions.Count(),
                TotalLockers = _context.LockerUnits.Count(),
                UserList = _context.Users.ToList(),
                LockerUsed = _context.LockerUnits.AsEnumerable().SelectMany(l => new string[] { l.Item1, l.Item2, l.Item3, l.Item4, l.Item5 }).Count(s => s != null)
            };
            return dashboard;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            List<ApplicationUser> users = _context.Users.Select(u => new ApplicationUser
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                LockerId = u.LockerId,
                Email = u.Email,
                CreatedOn = u.CreatedOn,
                CreatedBy = u.CreatedBy
            }).ToList();
            return users;
        }

        public List<UserEvent> GetUserEventdetails()
        {
            List<UserEvent> logs = _context.UserEvents.Where(x => x.Id == 1).ToList();
            return logs;
        }

        public LocationModel? GetLocationDetails(int locationId)
        {
            LocationModel? location = _context.Locations.FirstOrDefault(x => x.LocationId == locationId);
            return location;
        }
        public DivisionModel? GeDivisionDetails(int divisionId)
        {
            DivisionModel? division = _context.Divisions.FirstOrDefault(x => x.DivisionId == divisionId);
            return division;
        }

        public bool AddDivisionsByLocation(LocationModel location)
        {
            if(location == null)
                return false;

            LocationModel? existingLocation = _context.Locations.FirstOrDefault(x => x.LocationId == location.LocationId);
            if (location == null)
                return false;

            if (location.TotalDivision < 1)
                return false;

            int totalDivision = existingLocation.TotalDivision + location.TotalDivision;
            int divisionIdStart = existingLocation.TotalDivision + 1;

            AddNewDivision(totalDivision, divisionIdStart, location);

            existingLocation.TotalDivision = totalDivision;
            _context.SaveChanges();

            return true;
        }

        public UserReportsModel UserReport()
        {
            UserReportsModel userReport = new()
            {
                Users = _context.Users.Select(user => new ApplicationUser
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    LockerId = user.LockerId,
                    Email = user.Email,
                    CreatedOn = user.CreatedOn,
                    CreatedBy = user.CreatedBy
                }).ToList(),
                UserEvents = _context.UserEvents.ToList()
            };

            return userReport;
        }
    }
}
