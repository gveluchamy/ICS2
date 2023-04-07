using ICSLockers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ICSLockers.Repository.IRepository
{
    public interface ILockerManager
    {
        List<LockerUnits> GetLockerUnits();
        Tuple<bool, string> CreateNewLockerUnit(LockerUnits lockerUnits, ApplicationUser? user);
        List<LockerDetailsModel> GetLockersByLockerUnit(int lockerUnitId);
    }
}
