using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager_Backend.Migrations
{
    /// <inheritdoc />
    public partial class defaultvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_user_roles",
                columns: new[] { "Id", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 14, 19, 40, 56, 149, DateTimeKind.Local).AddTicks(7661), "Admin for Task Manager", "Admin" },
                    { 2, new DateTime(2026, 3, 14, 19, 40, 56, 150, DateTimeKind.Local).AddTicks(8819), "User for Task Manager", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_user_roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_user_roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
