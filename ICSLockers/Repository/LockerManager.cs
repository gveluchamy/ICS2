using ICSLockers.Data;
using ICSLockers.Helpers;
using ICSLockers.Models;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ICSLockers.Repository
{
    public class LockerManager: ILockerManager
    {
        private readonly ApplicationDbContext _context;

        public LockerManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<LockerUnits> GetLockerUnits()
        {          
            List<LockerUnits> lockerUnits = _context.LockerUnits.Where(x => !x.IsDeleted).ToList();
            return lockerUnits;           
        }

        public Tuple<bool, string> CreateNewLocker(LockerUnits lockerUnits)
        {
            bool IsSuccess = false;
            string Result = string.Empty;
            try
            {
                bool IsLockerUnitPresent = _context.LockerUnits.Any(model => model.LockerUnitNo == lockerUnits.LockerUnitNo);
                if (IsLockerUnitPresent)
                {
                    IsSuccess = false;
                    Result = $"New locker {lockerUnits.LockerUnitNo} is present already. Please choose other locker unit number!";
                }
                else
                {
                    _context.LockerUnits.Add(lockerUnits);
                    _context.SaveChanges();
                    IsSuccess = true;
                    Result = $"Locker unit {lockerUnits.LockerUnitNo} with locker {lockerUnits.TotalLocker} has been created.";
                }
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                Result = $"Some error has occurred in creating locker unit. Please try again later!";
            }
            return new Tuple<bool, string>(IsSuccess, Result);
        }
    }
}
