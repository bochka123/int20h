using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Int20h.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInformations_Groups_GroupId",
                table: "StudentInformations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c99630a-625d-4be4-82c9-97c1e8dbea4e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e99b3a7-414a-478e-ae32-bfabe72e6a9e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("916e01d6-ba89-4d35-a38c-7ad09faca7f4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "StudentInformations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "StudentInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1a4a4b58-9b15-43d8-9c07-389470c70987"), null, null, "student", null, null },
                    { new Guid("df2021f9-575f-478e-967b-66a114a0b5f0"), null, null, "teacher", null, null },
                    { new Guid("e420e11a-a57e-4c47-8c2a-f4dce25227df"), null, null, "admin", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInformations_Groups_GroupId",
                table: "StudentInformations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInformations_Groups_GroupId",
                table: "StudentInformations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a4a4b58-9b15-43d8-9c07-389470c70987"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("df2021f9-575f-478e-967b-66a114a0b5f0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e420e11a-a57e-4c47-8c2a-f4dce25227df"));

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "StudentInformations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "StudentInformations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5c99630a-625d-4be4-82c9-97c1e8dbea4e"), null, null, "student", null, null },
                    { new Guid("8e99b3a7-414a-478e-ae32-bfabe72e6a9e"), null, null, "admin", null, null },
                    { new Guid("916e01d6-ba89-4d35-a38c-7ad09faca7f4"), null, null, "teacher", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInformations_Groups_GroupId",
                table: "StudentInformations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
