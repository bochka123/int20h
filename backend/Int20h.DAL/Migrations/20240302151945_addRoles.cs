using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Int20h.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("085c159d-917c-4cb5-afea-61b5e3bbc524"), null, null, "admin", null, null },
                    { new Guid("203739e4-a6bc-44f8-9f53-a5c22e7a427e"), null, null, "teacher", null, null },
                    { new Guid("430eb4fb-5747-41ac-8756-3840fd9debc1"), null, null, "student", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("085c159d-917c-4cb5-afea-61b5e3bbc524"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("203739e4-a6bc-44f8-9f53-a5c22e7a427e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("430eb4fb-5747-41ac-8756-3840fd9debc1"));
        }
    }
}
