using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TheRealManSys.Migrations.ManSysRequest
{
    /// <inheritdoc />
    public partial class AddNullableFieldsInRequestAndItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_RequestStatuses_StatusId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_contacts_VendorContactsId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_StatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_DeliveryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_ManagerId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_RequestItems_VendorContactsId",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "VendorContactsId",
                table: "RequestItems");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Requests",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Requests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryId",
                table: "Requests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Store",
                table: "RequestItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "RequestItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "RequestItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "drafts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drafts_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "draftItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    CountType = table.Column<string>(type: "text", nullable: false),
                    draftId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_draftItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_draftItems_drafts_draftId",
                        column: x => x.draftId,
                        principalTable: "drafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_VendorId",
                table: "RequestItems",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_draftItems_draftId",
                table: "draftItems",
                column: "draftId");

            migrationBuilder.CreateIndex(
                name: "IX_drafts_UserId",
                table: "drafts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_RequestStatuses_StatusId",
                table: "RequestItems",
                column: "StatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_contacts_VendorId",
                table: "RequestItems",
                column: "VendorId",
                principalTable: "contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestStatuses_StatusId",
                table: "Requests",
                column: "StatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_User_DeliveryId",
                table: "Requests",
                column: "DeliveryId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_User_ManagerId",
                table: "Requests",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_RequestStatuses_StatusId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_contacts_VendorId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_StatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_DeliveryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_ManagerId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "draftItems");

            migrationBuilder.DropTable(
                name: "drafts");

            migrationBuilder.DropIndex(
                name: "IX_RequestItems_VendorId",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "RequestItems");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Requests",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryId",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Store",
                table: "RequestItems",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "RequestItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorContactsId",
                table: "RequestItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_VendorContactsId",
                table: "RequestItems",
                column: "VendorContactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_RequestStatuses_StatusId",
                table: "RequestItems",
                column: "StatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_contacts_VendorContactsId",
                table: "RequestItems",
                column: "VendorContactsId",
                principalTable: "contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestStatuses_StatusId",
                table: "Requests",
                column: "StatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_User_DeliveryId",
                table: "Requests",
                column: "DeliveryId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_User_ManagerId",
                table: "Requests",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
