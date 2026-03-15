using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager_Backend.Migrations
{
    /// <inheritdoc />
    public partial class emailunique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tb_users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "tb_user_roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 15, 23, 12, 13, 138, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "tb_user_roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 15, 23, 12, 13, 139, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_Email",
                table: "tb_users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_users_Email",
                table: "tb_users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tb_users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "tb_user_roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 14, 19, 40, 56, 149, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "tb_user_roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 3, 14, 19, 40, 56, 150, DateTimeKind.Local).AddTicks(8819));
        }
    }
}
