using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class test11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9a79090-295f-4303-bf34-48f1f5846f1f", "4318cab1-bd2b-430f-b2f3-c7532525ecd9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "312c0a79-0112-4672-803a-5e459d2d8f3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9a79090-295f-4303-bf34-48f1f5846f1f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4318cab1-bd2b-430f-b2f3-c7532525ecd9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "318e8775-3d6e-435e-a35d-4815d824f664", "318e8775-3d6e-435e-a35d-4815d824f664", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "64724448-ab5d-4b59-8f38-d8e51ce1430e", 0, "8a049850-f917-4274-b5d6-3e0bad0c576b", "tomek@gmail.com", true, false, null, "TOMEK@GMAIL.COM", "TOMEK", "AQAAAAIAAYagAAAAEPusSJmIc8w0hJCGkO17K0ItBUlY74oWUi+iE8lyNxLuwmOH6o89yOsrUCp3CIX+aw==", null, false, "0cfefd46-e0ac-418c-b293-6f5cc07a0ee5", false, "tomek" },
                    { "64a03d67-cc54-4031-a578-9a9f0c6a3efc", 0, "72118a1a-fb3d-43a5-aa77-8fe9336ad8fd", "jacek@gmail.com", true, false, null, "JACEK@GMAIL.COM", "JACEK", "AQAAAAIAAYagAAAAEHSkk3Yag0KKbvuwXGE6Q4Jjn9dJYRSJlOqw5CAkJAEqWU1CytUsifdeNjfoV4jsgQ==", null, false, "dc47ce11-6454-4965-91e3-d870fee09ff8", false, "jacek" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "318e8775-3d6e-435e-a35d-4815d824f664", "64a03d67-cc54-4031-a578-9a9f0c6a3efc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "318e8775-3d6e-435e-a35d-4815d824f664", "64a03d67-cc54-4031-a578-9a9f0c6a3efc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64724448-ab5d-4b59-8f38-d8e51ce1430e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "318e8775-3d6e-435e-a35d-4815d824f664");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64a03d67-cc54-4031-a578-9a9f0c6a3efc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9a79090-295f-4303-bf34-48f1f5846f1f", "c9a79090-295f-4303-bf34-48f1f5846f1f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "312c0a79-0112-4672-803a-5e459d2d8f3e", 0, "ddd59461-f3ff-4ca4-8cfa-7fb03aa66544", "tomek@gmail.com", true, false, null, "TOMEK@GMAIL.COM", "TOMEK", "AQAAAAIAAYagAAAAEPff5W3E17o6x48NIdgn2qZWDEb+0AJgz6XecCuZs/oNK8u1wgztQ9yC5PYmQ8TBAQ==", null, false, "df7aaf4c-8173-4b1c-9b5b-764e2587435d", false, "tomek" },
                    { "4318cab1-bd2b-430f-b2f3-c7532525ecd9", 0, "9395f077-521d-42f6-850e-2125bc3f53d5", "jacek@gmail.com", true, false, null, "JACEK@GMAIL.COM", "JACEK", "AQAAAAIAAYagAAAAEE5c7m30f3kibyKc+iJ0R3KV3KsMmsk1aArJE+69wFDPAonKb5bWE7zffdS03vdHlg==", null, false, "af8f04dd-fb32-432e-87a5-3de88e5ec736", false, "jacek" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c9a79090-295f-4303-bf34-48f1f5846f1f", "4318cab1-bd2b-430f-b2f3-c7532525ecd9" });
        }
    }
}
