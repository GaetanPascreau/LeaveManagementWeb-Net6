using LeaveManagement.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "09ee071c-ed16-42ca-be60-a6e0b7e1ae29",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "465b590d-d7cd-4b1f-b897-de900e81ac5c",
                    Name = Roles.Supervisor,
                    NormalizedName = Roles.Supervisor.ToUpper()
                },
                new IdentityRole
                {
                    Id = "afccf3f3-12b4-4657-b24a-6642f8e34298",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                }
            );
        }
    }
}