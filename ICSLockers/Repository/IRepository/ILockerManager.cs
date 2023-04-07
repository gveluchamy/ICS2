using ICSLockers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ICSLockers.Repository.IRepository
{
    public interface ILockerManager
    {
        List<LockerUnits> GetLockerUnits();
        Tuple<bool, string> CreateNewLocker(LockerUnits lockerUnits);
    }
}
