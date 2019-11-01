using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_MailApplicationsManager.Models.Seed
{
    public static class ApplicationUserSeed
    {
        public static void UserRole(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RoleUser>()
                .HasData(SeedRoles());

            var hasher = new PasswordHasher<User>();

            var adminDiyan = new User
            {
                Id = "c23c3678-6194-4b7e-a928-09614190eb62",
                UserName = "Diyan",
                NormalizedUserName = "DIYAN",
                Email = "admin1@admin.com",
                NormalizedEmail = "ADMIN1@ADMIN.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                LockoutEnabled = true,
                FirstLog = true
            };
            var adminBobi = new User
            {
                Id = "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                UserName = "Bobi",
                NormalizedUserName = "BOBI",
                Email = "admin2@admin.com",
                NormalizedEmail = "ADMIN2@ADMIN.COM",
                SecurityStamp = "74CLJEIXNYLPRXMVXXNSWXZH6R6KJRRU",
                LockoutEnabled = true,
                FirstLog = true
            };

            adminDiyan.PasswordHash = hasher.HashPassword(adminDiyan, "123456");
            adminBobi.PasswordHash = hasher.HashPassword(adminBobi, "234567");
            modelBuilder.Entity<User>().HasData(adminDiyan, adminBobi);

            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    UserId = adminDiyan.Id,
                    RoleId = "ca678235-7571-4177-984f-e9d1957b0187"
                },
                  new IdentityUserRole<string>
                  { UserId = adminBobi.Id, RoleId = "ca678235-7571-4177-984f-e9d1957b0187" });
        }

        private static RoleUser[] SeedRoles()
        {

            var userRole = new RoleUser[]
            {
                 new RoleUser
                 {

                     Id = "ca678235-7571-4177-984f-e9d1957b0187",
                     Name = "Manager",
                     NormalizedName = "MANAGER"
                 },
                new RoleUser
                {
                    Id = "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                },
            };
            return userRole;
        }
    }
}