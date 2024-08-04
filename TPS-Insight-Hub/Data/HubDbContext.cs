using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TPS_Insight_Hub.Models;
using System.Collections.Generic;

namespace TPS_Insight_Hub
{
    public class HubDbContext : IdentityDbContext<ApplicationUser>
    {
        public HubDbContext(DbContextOptions<HubDbContext> options) : base(options)
        {
        }

        public DbSet<LookUpPosition> Positions { get; set; }
        public DbSet<LookUpDepartment> Departments { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            seedRole(modelBuilder, "admin");
            seedRole(modelBuilder, "user");

            seedPositions(modelBuilder);
            seedDepartments(modelBuilder);
            seedUsers(modelBuilder);
        }

        private void seedRole(ModelBuilder modelBuilder, string roleName)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);
        }

        private void seedPositions(ModelBuilder modelBuilder)
        {
            var positions = new List<LookUpPosition>
            {
                new LookUpPosition { Id = 1, Position = "Manager" },
                new LookUpPosition { Id = 2, Position = "Developer" },
                new LookUpPosition { Id = 3, Position = "Designer" },
                new LookUpPosition { Id = 4, Position = "Tester" },
                new LookUpPosition { Id = 5, Position = "Support" },
                new LookUpPosition { Id = 6, Position = "HR" },
                new LookUpPosition { Id = 7, Position = "Sales" },
                new LookUpPosition { Id = 8, Position = "Marketing" },
                new LookUpPosition { Id = 9, Position = "Finance" },
                new LookUpPosition { Id = 10, Position = "Admin" }
            };

            modelBuilder.Entity<LookUpPosition>().HasData(positions);
        }

        private void seedDepartments(ModelBuilder modelBuilder)
        {
            var departments = new List<LookUpDepartment>
            {
                new LookUpDepartment { Id = 1, Name = "IT" },
                new LookUpDepartment { Id = 2, Name = "HR" },
                new LookUpDepartment { Id = 3, Name = "Sales" },
                new LookUpDepartment { Id = 4, Name = "Marketing" },
                new LookUpDepartment { Id = 5, Name = "Finance" },
                new LookUpDepartment { Id = 6, Name = "Admin" },
                new LookUpDepartment { Id = 7, Name = "Support" },
                new LookUpDepartment { Id = 8, Name = "Development" },
                new LookUpDepartment { Id = 9, Name = "Design" },
                new LookUpDepartment { Id = 10, Name = "Testing" }
            };

            modelBuilder.Entity<LookUpDepartment>().HasData(departments);
        }

        private void seedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "admin-id",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    SecurityStamp = string.Empty,
                    PositionId = 1,
                    DepartmentId = 1
                }
            };

            for (int i = 1; i <= 12; i++)
            {
                users.Add(new ApplicationUser
                {
                    Id = $"user-{i}",
                    UserName = $"user{i}",
                    NormalizedUserName = $"USER{i}",
                    Email = $"user{i}@example.com",
                    NormalizedEmail = $"USER{i}@EXAMPLE.COM",
                    PhoneNumber = $"079999999{i}",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User@123"),
                    SecurityStamp = string.Empty,
                    PositionId = i % 10 + 1, // Cycle through positions
                    DepartmentId = i % 10 + 1 // Cycle through departments
                });
            }

            modelBuilder.Entity<ApplicationUser>().HasData(users);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "admin",
                UserId = "admin-id"
            });

            for (int i = 1; i <= 12; i++)
            {
                modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    RoleId = "user",
                    UserId = $"user-{i}"
                });
            }
        }
    }
}
