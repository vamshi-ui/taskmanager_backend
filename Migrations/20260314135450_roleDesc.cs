using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager_Backend.Migrations
{
    /// <inheritdoc />
    public partial class roleDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tb_user_roles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "tb_user_roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tb_user_roles");
        }
    }
}
