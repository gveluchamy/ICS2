using ICSLockers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ICSLockers.Repository.IRepository
{
    public interface ILockerManager
    {
        List<LockerUnits> GetLockerUnits();
        bool CreateNewLockerAsync(LockerUnits lockerUnits);
    }
}
