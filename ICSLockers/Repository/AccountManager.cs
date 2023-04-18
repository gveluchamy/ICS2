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
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountManager(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateNewUserAsync(RegistrationModel model)
        {
            var status = new IdentityResult();
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {                
               
                return status;
            }
           
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = false,
                PhoneNumberConfirmed =false,
                PasswordEnc = AccountHelper.CreatePassword(model)
        };
           
            try
            {
                var result = await _userManager.CreateAsync(user, user.PasswordEnc);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            var RoleName = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Role).Name;
            if (!await _roleManager.RoleExistsAsync(RoleName))
                await _roleManager.CreateAsync(new IdentityRole(model.Role));


            if (await _roleManager.RoleExistsAsync(RoleName))
            {

                await  _userManager.AddToRoleAsync(user, RoleName);
            }          
            
            return status;
            //string password = AccountHelper.CreatePassword(applicationUser);
            //applicationUser.PasswordEnc = password;

            //IdentityResult userResult = await _userManager.CreateAsync(applicationUser, password);

            //return userResult;
        }

        public ApplicationUser? FindUserByPassword(string password)
        {
            ApplicationUser? user = _userManager.Users?.FirstOrDefault(x=> password.Equals(x.PasswordEnc));
            return user;
        }

        public ApplicationUser? FindUserByEmail(string email)
        {
            ApplicationUser? user = _userManager.Users?.FirstOrDefault(x => email.Equals(x.Email));
            return user;
        }
        public async Task LogUserEventAsync(ApplicationUser user, bool isLogin)
        {

            var loginEvent = new UserEvent
            {
                UserId = user.Id,
                Username = user.UserName,
                Role = null,
                EventType = isLogin ? UserEventType.Login : UserEventType.Logout,
                EventTime = DateTime.UtcNow
            };


            _context.UserEvents.Add(loginEvent);
            await _context.SaveChangesAsync();
        }
    }
}
