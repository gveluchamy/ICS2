using ICSLockers.Models;
using Microsoft.AspNetCore.Identity;

namespace ICSLockers.Repository.IRepository
{
    public interface IAccountManager
    {
        Task<IdentityResult> CreateNewUserAsync(ApplicationUser applicationUser);
        ApplicationUser FindUserByPassword(string password);
    }
}
