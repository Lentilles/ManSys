using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealManSys.Migrations.ManSysRequest
{
    /// <inheritdoc />
    public partial class AddingGlobalStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GlobalStatus",
                table: "RequestStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultOnCreateItem",
                table: "RequestStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GlobalStatus",
                table: "RequestStatuses");

            migrationBuilder.DropColumn(
                name: "IsDefaultOnCreateItem",
                table: "RequestStatuses");
        }
    }
}
