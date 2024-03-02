using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Int20h.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26af1f8b-521d-4bc5-870a-3cdad30efda1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5b0f1e26-527c-4178-8e58-509544615670"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9f99198-02fc-49f3-9bd1-7c7c2e483dc5"));

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "StudentInformations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MentorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_TeacherInformations_MentorId",
                        column: x => x.MentorId,
                        principalTable: "TeacherInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5c99630a-625d-4be4-82c9-97c1e8dbea4e"), null, null, "student", null, null },
                    { new Guid("8e99b3a7-414a-478e-ae32-bfabe72e6a9e"), null, null, "admin", null, null },
                    { new Guid("916e01d6-ba89-4d35-a38c-7ad09faca7f4"), null, null, "teacher", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_GroupId",
                table: "StudentInformations",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_MentorId",
                table: "Groups",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInformations_Groups_GroupId",
                table: "StudentInformations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInformations_Groups_GroupId",
                table: "StudentInformations");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_StudentInformations_GroupId",
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

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "StudentInformations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("26af1f8b-521d-4bc5-870a-3cdad30efda1"), null, null, "teacher", null, null },
                    { new Guid("5b0f1e26-527c-4178-8e58-509544615670"), null, null, "student", null, null },
                    { new Guid("e9f99198-02fc-49f3-9bd1-7c7c2e483dc5"), null, null, "admin", null, null }
                });
        }
    }
}
