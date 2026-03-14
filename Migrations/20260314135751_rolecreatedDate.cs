using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager_Backend.Migrations
{
    /// <inheritdoc />
    public partial class rolecreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_user_roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "tb_user_roles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "tb_user_roles");

            migrationBuilder.InsertData(
                table: "tb_user_roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "Admin" });
        }
    }
}
