using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole 
                { 
                  Id = "43139b63-f9d8-4daa-a133-5a65af281605",
                  Name = "Administrator", 
                  NormalizedName = "ADMINISTRATOR" 
                },
                new IdentityRole 
                {
                  Id = "fb6d5392-277a-4691-bb9c-830ef7113a76",
                  Name = "User", 
                  NormalizedName = "USER" 
                }
            );
        }
    }
}
