using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "8d30dbae-134d-4137-8e2e-ec7c96ee1d82",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    Employer = "Sogescot",
                    SupervisorId = "8d30dbae-134d-4137-8e2e-ec7c96ee1d82"
                },
                new Employee
                {
                    Id = "cf15a7b7-1533-4357-9dbd-20cddfff903c",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    Employer = "Sogescot",
                    SupervisorId = "3dce240b-4ce6-4202-b816-b5cc763352a7"
                },
                new Employee
                {
                    Id = "3dce240b-4ce6-4202-b816-b5cc763352a7",
                    Email = "supervisor@localhost.com",
                    NormalizedEmail = "SUPERVISOR@LOCALHOST.COM",
                    UserName = "supervisor@localhost.com",
                    NormalizedUserName = "SUPERVISOR@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Supervisor",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    Employer = "Sogescot",
                    SupervisorId = "8d30dbae-134d-4137-8e2e-ec7c96ee1d82"
                }
            );
        }
    }
}