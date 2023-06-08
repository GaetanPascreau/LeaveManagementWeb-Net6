using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "09ee071c-ed16-42ca-be60-a6e0b7e1ae29",
                    UserId = "8d30dbae-134d-4137-8e2e-ec7c96ee1d82" // this is the Administrator
                },
                new IdentityUserRole<string>
                {
                    RoleId = "afccf3f3-12b4-4657-b24a-6642f8e34298",
                    UserId = "cf15a7b7-1533-4357-9dbd-20cddfff903c" // this is a simple User
                },
                new IdentityUserRole<string>
                {
                    RoleId = "465b590d-d7cd-4b1f-b897-de900e81ac5c",
                    UserId = "3dce240b-4ce6-4202-b816-b5cc763352a7" // this is a Supervisor
                }
            );
        }
    }
}