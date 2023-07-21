using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealManSys.Migrations.ManSysRequest
{
    /// <inheritdoc />
    public partial class AddingDeliveryDateEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "Requests",
                newName: "DeliveryDateStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDateEnd",
                table: "Requests",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDateEnd",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "DeliveryDateStart",
                table: "Requests",
                newName: "DeliveryDate");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DeliveryTime",
                table: "Requests",
                type: "interval",
                nullable: true);
        }
    }
}
