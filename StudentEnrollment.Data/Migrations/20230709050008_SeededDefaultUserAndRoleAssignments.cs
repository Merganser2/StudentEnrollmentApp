using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserAndRoleAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a32932b-8167-4a79-984f-6d0fa5510a33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50348384-3b54-49f9-a044-f9b37098b70a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43139b63-f9d8-4daa-a133-5a65af281605", null, "Administrator", "ADMINISTRATOR" },
                    { "fb6d5392-277a-4691-bb9c-830ef7113a76", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "083fa975-03fd-46e5-b49f-e35aaf4e838c", 0, "9ecde2a7-9dbb-48a4-b4f1-447b6242831c", null, "schooladmin@localhost.com", true, "School", "Admin", false, null, "SCHOOLADMIN@LOCALHOST.COM", "SCHOOLADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEM7hXG32bW0hrVlyv3VRUCnPcJfq26s56P339xDIpYNKq84Kdc80v2FzPDfjoniPgg==", null, false, "aa335567-6cbd-4807-8a4a-93db9d43a319", false, "schooladmin@localhost.com" },
                    { "1d1fedb9-df06-450c-bbee-4aad81cadf89", 0, "79b4f817-f48e-4794-8fb2-03235b7d9f48", null, "schooluser@localhost.com", true, "School", "User", false, null, "SCHOOLUSER@LOCALHOST.COM", "SCHOOLUSER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBg+pfYwdlyS5NvySI7oJeHWcxnsMOXAVpESBYRp6AGyJv6zmNUgQATfGyewDH7aYw==", null, false, "ad7b6aa4-de85-4157-8167-c3f92922751e", false, "schooluser@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "43139b63-f9d8-4daa-a133-5a65af281605", "083fa975-03fd-46e5-b49f-e35aaf4e838c" },
                    { "fb6d5392-277a-4691-bb9c-830ef7113a76", "1d1fedb9-df06-450c-bbee-4aad81cadf89" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "43139b63-f9d8-4daa-a133-5a65af281605", "083fa975-03fd-46e5-b49f-e35aaf4e838c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb6d5392-277a-4691-bb9c-830ef7113a76", "1d1fedb9-df06-450c-bbee-4aad81cadf89" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43139b63-f9d8-4daa-a133-5a65af281605");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb6d5392-277a-4691-bb9c-830ef7113a76");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "083fa975-03fd-46e5-b49f-e35aaf4e838c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1fedb9-df06-450c-bbee-4aad81cadf89");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a32932b-8167-4a79-984f-6d0fa5510a33", null, "User", "USER" },
                    { "50348384-3b54-49f9-a044-f9b37098b70a", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
