using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManSys.Migrations.ManSysRequest
{
    /// <inheritdoc />
    public partial class FixRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_CreatorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DeliveryId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ManagerId",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CreatorId",
                table: "Requests",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeliveryId",
                table: "Requests",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ManagerId",
                table: "Requests",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_CreatorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DeliveryId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ManagerId",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CreatorId",
                table: "Requests",
                column: "CreatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeliveryId",
                table: "Requests",
                column: "DeliveryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ManagerId",
                table: "Requests",
                column: "ManagerId",
                unique: true);
        }
    }
}
