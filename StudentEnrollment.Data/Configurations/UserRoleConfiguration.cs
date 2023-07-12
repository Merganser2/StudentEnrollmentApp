using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            // UserRoles for 1) Admin, 2) User;
            //   RoleIds match corresponding Ids for Admin, User in RoleConfiguration class
            //   UserIds match corresponding Ids for Admin, User in SchoolEnrollmentUserConfiguration class
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "43139b63-f9d8-4daa-a133-5a65af281605",
                    UserId = "083fa975-03fd-46e5-b49f-e35aaf4e838c",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fb6d5392-277a-4691-bb9c-830ef7113a76",
                    UserId = "1d1fedb9-df06-450c-bbee-4aad81cadf89",
                }
            );
        }
    }
}
