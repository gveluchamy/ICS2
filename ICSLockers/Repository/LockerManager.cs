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
        
        public bool CreateNewLockerAsync(LockerUnits lockerUnits)
        {          
            _context.LockerUnits.Add(lockerUnits);
            _context.SaveChanges();
            return true;           
            
        }

       
    }
}
