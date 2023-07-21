using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealManSys.Migrations.ManSysRequest
{
    /// <inheritdoc />
    public partial class ChangeRequestTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_User_CreatorId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_User_ReplyId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_request_RequestId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_items_contacts_VendorContactsId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_items_request_RequestId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_items_status_StatusId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_request_User_CreatorId",
                table: "request");

            migrationBuilder.DropForeignKey(
                name: "FK_request_User_DeliveryId",
                table: "request");

            migrationBuilder.DropForeignKey(
                name: "FK_request_User_ManagerId",
                table: "request");

            migrationBuilder.DropForeignKey(
                name: "FK_request_status_StatusId",
                table: "request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_status",
                table: "status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_request",
                table: "request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "status",
                newName: "RequestStatuses");

            migrationBuilder.RenameTable(
                name: "request",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "items",
                newName: "RequestItems");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "RequestComments");

            migrationBuilder.RenameIndex(
                name: "IX_request_StatusId",
                table: "Requests",
                newName: "IX_Requests_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_request_ManagerId",
                table: "Requests",
                newName: "IX_Requests_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_request_DeliveryId",
                table: "Requests",
                newName: "IX_Requests_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_request_CreatorId",
                table: "Requests",
                newName: "IX_Requests_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_items_VendorContactsId",
                table: "RequestItems",
                newName: "IX_RequestItems_VendorContactsId");

            migrationBuilder.RenameIndex(
                name: "IX_items_StatusId",
                table: "RequestItems",
                newName: "IX_RequestItems_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_items_RequestId",
                table: "RequestItems",
                newName: "IX_RequestItems_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_RequestId",
                table: "RequestComments",
                newName: "IX_RequestComments_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_ReplyId",
                table: "RequestComments",
                newName: "IX_RequestComments_ReplyId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_CreatorId",
                table: "RequestComments",
                newName: "IX_RequestComments_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestItems",
                table: "RequestItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestComments",
                table: "RequestComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestComments_Requests_RequestId",
                table: "RequestComments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestComments_User_CreatorId",
                table: "RequestComments",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestComments_User_ReplyId",
                table: "RequestComments",
                column: "ReplyId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_RequestStatuses_StatusId",
                table: "RequestItems",
                column: "StatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_Requests_RequestId",
                table: "RequestItems",
                column: "RequestId",
                principalTable: "Requests",
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
                name: "FK_Requests_User_CreatorId",
                table: "Requests",
                column: "CreatorId",
                principalTable: "User",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestComments_Requests_RequestId",
                table: "RequestComments");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestComments_User_CreatorId",
                table: "RequestComments");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestComments_User_ReplyId",
                table: "RequestComments");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_RequestStatuses_StatusId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_Requests_RequestId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_contacts_VendorContactsId",
                table: "RequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_StatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_CreatorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_DeliveryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_ManagerId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestItems",
                table: "RequestItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestComments",
                table: "RequestComments");

            migrationBuilder.RenameTable(
                name: "RequestStatuses",
                newName: "status");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "request");

            migrationBuilder.RenameTable(
                name: "RequestItems",
                newName: "items");

            migrationBuilder.RenameTable(
                name: "RequestComments",
                newName: "comments");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_StatusId",
                table: "request",
                newName: "IX_request_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ManagerId",
                table: "request",
                newName: "IX_request_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_DeliveryId",
                table: "request",
                newName: "IX_request_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_CreatorId",
                table: "request",
                newName: "IX_request_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_VendorContactsId",
                table: "items",
                newName: "IX_items_VendorContactsId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_StatusId",
                table: "items",
                newName: "IX_items_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_RequestId",
                table: "items",
                newName: "IX_items_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestComments_RequestId",
                table: "comments",
                newName: "IX_comments_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestComments_ReplyId",
                table: "comments",
                newName: "IX_comments_ReplyId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestComments_CreatorId",
                table: "comments",
                newName: "IX_comments_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_status",
                table: "status",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_request",
                table: "request",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_User_CreatorId",
                table: "comments",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_User_ReplyId",
                table: "comments",
                column: "ReplyId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_request_RequestId",
                table: "comments",
                column: "RequestId",
                principalTable: "request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_contacts_VendorContactsId",
                table: "items",
                column: "VendorContactsId",
                principalTable: "contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_request_RequestId",
                table: "items",
                column: "RequestId",
                principalTable: "request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_status_StatusId",
                table: "items",
                column: "StatusId",
                principalTable: "status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_request_User_CreatorId",
                table: "request",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_request_User_DeliveryId",
                table: "request",
                column: "DeliveryId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_request_User_ManagerId",
                table: "request",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_request_status_StatusId",
                table: "request",
                column: "StatusId",
                principalTable: "status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
