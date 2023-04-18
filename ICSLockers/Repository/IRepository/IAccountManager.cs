using ICSLockers.Models;
using Microsoft.AspNetCore.Identity;

namespace ICSLockers.Repository.IRepository
{
    public interface IAccountManager
    {
        Task<IdentityResult> CreateNewUserAsync(RegistrationModel applicationUser);
        ApplicationUser FindUserByPassword(string password);
        ApplicationUser FindUserByEmail(string email);
        Task LogUserEventAsync(ApplicationUser user, bool isLogin);
    }
}
