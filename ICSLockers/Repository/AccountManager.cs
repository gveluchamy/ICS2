using ICSLockers.Data;
using ICSLockers.Helpers;
using ICSLockers.Models;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ICSLockers.Repository
{
    public class AccountManager : IAccountManager
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountManager(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateNewUserAsync(ApplicationUser applicationUser)
        {
            string password = AccountHelper.CreatePassword(applicationUser);
            applicationUser.PasswordEnc = password;

            IdentityResult userResult = await _userManager.CreateAsync(applicationUser, password);

            return userResult;
        }

        public ApplicationUser? FindUserByPassword(string password)
        {
            var encPassword = password;//AccountHelper.CreatePassword(applicationUser);
            ApplicationUser? user = _userManager.Users?.FirstOrDefault(x=> password.Equals(x.PasswordEnc));

            return user;
        }
    }
}
