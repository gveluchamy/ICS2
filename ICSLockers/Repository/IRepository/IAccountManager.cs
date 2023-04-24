using ICSLockers.Models;
using Microsoft.AspNetCore.Identity;

namespace ICSLockers.Repository.IRepository
{
    public interface IAccountManager
    {
        Task<Tuple<bool, string>> LoginAsync(LoginViewModel model, string? page = null);
        Task SignOutAsync(string userEmail);
        Task<IdentityResult> CreateNewUserAsync(RegistrationModel applicationUser);
        ApplicationUser FindUserByPassword(string password);
        Task LogUserEventAsync(string email, bool isLogin);
    }
}
