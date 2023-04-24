using ICSLockers.Data;
using ICSLockers.Helpers;
using ICSLockers.Models;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ICSLockers.Repository
{
    public class AccountManager : IAccountManager
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountManager(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<Tuple<bool, string>> LoginAsync(LoginViewModel model, string? page = null)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return new Tuple<bool, string>(false, "Invalid Creadentials. Please try again!");
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new Tuple<bool, string>(false, "Invalid Creadentials. Please try again!");
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (signInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                await LogUserEventAsync(user.UserName, true);

                return new Tuple<bool, string>(true, $"Welcome back {user.FullName}!. You have signed in Successfully.");
            }
            else
            {
                return new Tuple<bool, string>(false, $"Some error has occurred in logging in. Please try again later!");
            }
        }

        public async Task SignOutAsync(string userEmail)
        {
            await LogUserEventAsync(userEmail, false);
            await _signInManager.SignOutAsync();
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
                SSN=model.SSN,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                PasswordEnc = AccountHelper.CreatePassword(model),
                CheckOutStatus=false
            };

            try
            {
                var result = await _userManager.CreateAsync(user, user.PasswordEnc);
            }
            catch (Exception ex)
            {
                return status;
            }

            var RoleName = _roleManager.Roles.FirstOrDefault(x => x.Id.Equals( model.Role)).Name;

            if (await _roleManager.RoleExistsAsync(RoleName))
            {
               await _userManager.AddToRoleAsync(user, RoleName);
            }
            
            return IdentityResult.Success;
        }

        public ApplicationUser? FindUserByPassword(string password)
        {
            ApplicationUser? user = _userManager.Users?.FirstOrDefault(x => password.Equals(x.PasswordEnc));
            return user;
        }
           
        public async Task LogUserEventAsync(string email, bool isLogin)
        {
            var user =  _userManager.Users.FirstOrDefault(x=> x.UserName == email);
            var userRole = await _userManager.GetRolesAsync(user);
            try
            {
                UserEvent loginEvent = new()
                {
                    UserId = user.Id,
                    Username = user.FullName,
                    Role = userRole.First(),
                    EventType = isLogin ? UserEventType.Login : UserEventType.Logout,
                    EventTime = DateTime.Now
                };

                _context.UserEvents.Add(loginEvent);
                _context.SaveChanges();
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex);
            }
        }
    }
}
