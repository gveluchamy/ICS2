using ICSLockers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ICSLockers.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);            
            SeedUsers(builder);
            SeedUserRoles(builder);
        }
        private static void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser user = new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "icslocker@hotmail.com",
                NormalizedUserName = "icslocker@hotmail.com",
                Email = "icslocker@hotmail.com",
                NormalizedEmail = "icslocker@hotmail.com",
                LockoutEnabled = true,
                PhoneNumber = "9876543210",
                EmailConfirmed = true,
                FirstName = "ICS",
                LastName = "Lockers",
                CreatedOn = DateTime.Now,
                CreatedBy = "Admin",
                SSN = 987654311,
                CheckOutStatus = false,
                PasswordEnc = "IL11",
                LockerUnitId = 0,
                LockerDetailId = 0,
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordEnc);

            builder.Entity<ApplicationUser>().HasData(user);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "b6011125-2b8d-442a-9717-b8cf5345b015", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole { Id = "c76d8f8d-9e53-433c-b8e3-96fddb7ac25b", Name = "Staff", ConcurrencyStamp = "2", NormalizedName = "Staff" },
                new IdentityRole { Id = "865d7c89-436d-43a3-946b-f36896d64ccf", Name = "User", ConcurrencyStamp = "3", NormalizedName = "User" }
            );
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "b6011125-2b8d-442a-9717-b8cf5345b015", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }


        #region DbSet
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<DivisionModel> Divisions { get; set; }
        public DbSet<LockerUnitModel>LockerUnits { get; set; }
        #endregion
    }
}