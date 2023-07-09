using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations
{
    internal class SchoolEnrollmentUserConfiguration : IEntityTypeConfiguration<SchoolEnrollmentUser>
    {
        public void Configure(EntityTypeBuilder<SchoolEnrollmentUser> builder)
        {
            var hasher = new PasswordHasher<SchoolEnrollmentUser>();

            builder.HasData(
                            new SchoolEnrollmentUser
                            {
                                Id = "083fa975-03fd-46e5-b49f-e35aaf4e838c",
                                Email = "schooladmin@localhost.com",
                                NormalizedEmail = "SCHOOLADMIN@LOCALHOST.COM",
                                NormalizedUserName = "SCHOOLADMIN@LOCALHOST.COM",
                                UserName = "schooladmin@localhost.com",
                                FirstName = "School",
                                LastName = "Admin",
                                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                                EmailConfirmed = true
                            },
                            new SchoolEnrollmentUser
                            {
                                Id = "1d1fedb9-df06-450c-bbee-4aad81cadf89",
                                Email = "schooluser@localhost.com",
                                NormalizedEmail = "SCHOOLUSER@LOCALHOST.COM",
                                NormalizedUserName = "SCHOOLUSER@LOCALHOST.COM",
                                UserName = "schooluser@localhost.com",
                                FirstName = "School",
                                LastName = "User",
                                PasswordHash = hasher.HashPassword(null, "P@ssword2"),
                                EmailConfirmed = true
                            }
                        );
        }
    }
}
