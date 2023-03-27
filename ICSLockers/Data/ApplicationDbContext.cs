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
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id= "b6011125-2b8d-442a-9717-b8cf5345b015", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole { Id= "c76d8f8d-9e53-433c-b8e3-96fddb7ac25b", Name = "Staff", ConcurrencyStamp = "2", NormalizedName = "Staff" },
                new IdentityRole { Id= "865d7c89-436d-43a3-946b-f36896d64ccf", Name = "User", ConcurrencyStamp = "3", NormalizedName = "User" }
            );
        }
    }
}