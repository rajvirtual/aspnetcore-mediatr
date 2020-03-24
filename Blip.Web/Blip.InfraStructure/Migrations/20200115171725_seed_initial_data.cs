using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blip.InfraStructure.Migrations
{
    public partial class seed_initial_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Author", "CreatedBy", "CreatedDate", "Post", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "William", "Josh", new DateTime(2020, 1, 15, 12, 17, 24, 335, DateTimeKind.Local).AddTicks(9941), "Test Blog", "Josh", new DateTime(2020, 1, 15, 12, 17, 24, 342, DateTimeKind.Local).AddTicks(6263) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogId", "CommentText", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, "Test Comment", "Josh", new DateTime(2020, 1, 15, 12, 17, 24, 345, DateTimeKind.Local).AddTicks(8570), "Josh", new DateTime(2020, 1, 15, 12, 17, 24, 345, DateTimeKind.Local).AddTicks(9632) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
