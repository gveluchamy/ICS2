using ICSLockers.Data;
using ICSLockers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                var locationName=location.LocationName;
                bool IsLocationPresent = _context.Locations.ToList().Any(x => x.LocationName.Equals(location.LocationName, StringComparison.OrdinalIgnoreCase));
                if (!IsLocationPresent)
                {
                    if (locationName != "")
                    {
                        var test = _context.Locations.Add(location);
                        _context.SaveChanges();

                        if (location.TotalDivision > 0)
                        {
                            for (int i = 1; i <= location.TotalDivision; i++)
                            {
                                DivisionModel division = new()
                                {
                                    DivisionNo = i,
                                    TotalLockers = 5,
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
               
                if (division.TotalLockers > 0)
                {
                    for (int i = 1; i <= division.TotalLockers; i++)
                    {
                        LockerUnitModel lockerUnit = new()
                        {
                            
                            DivisionId = division.DivisionId,
                            CreatedBy = division.CreatedBy,
                            ModifiedBy = division.ModifiedBy,
                            CreatedOn = DateTime.Now,
                            ModifiedOn = DateTime.Now,
                        };
                        AddLocker(lockerUnit);
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
           
            return true;
        }

        public Tuple<bool, string> UpdateDivisionByDivisionID(DivisionModel division)
        {
            bool IsSuccess = false;
            string Result = string.Empty;
            if (division != null)
            {
                _context.Divisions.Add(division);
                _context.SaveChanges();
            }
            return new Tuple<bool, string>(IsSuccess, Result);
        }

        public List<LockerUnitModel> GetLockerUnitsByDivisionId(int divisionId)
        {
            List<LockerUnitModel> lockerUnits = _context.LockerUnits.Where(x => x.DivisionId == divisionId).ToList();
            return lockerUnits;
        }

        public bool AddLocker(LockerUnitModel lockerUnit)
        {
            try
            {
                _context.LockerUnits.Add(lockerUnit);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                LockerUsed = 0,
                UserList = _context.Users.ToList()
            };

            return dashboard;
        }
    }
}
