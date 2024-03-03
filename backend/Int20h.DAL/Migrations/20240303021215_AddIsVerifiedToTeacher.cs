using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Int20h.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIsVerifiedToTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f53458e-f4ef-4b96-a0ac-65726f0344c2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("752e890e-7776-45db-8474-fcf486b12c9c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("78d0a866-efe5-47b2-bd1b-71ea707b04e3"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "TeacherInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "TeacherInformations");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5f53458e-f4ef-4b96-a0ac-65726f0344c2"), null, null, "admin", null, null },
                    { new Guid("752e890e-7776-45db-8474-fcf486b12c9c"), null, null, "teacher", null, null },
                    { new Guid("78d0a866-efe5-47b2-bd1b-71ea707b04e3"), null, null, "student", null, null }
                });
        }
    }
}
