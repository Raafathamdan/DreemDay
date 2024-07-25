using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreemDay.Migrations
{
    /// <inheritdoc />
    public partial class realtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Services_ServiceId",
                table: "WishLists",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Users_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Services_ServiceId",
                table: "WishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Users_UserId",
                table: "WishLists");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_WishLists_ServiceId",
                table: "WishLists",
                column: "ServiceId",
                principalTable: "WishLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_WishLists_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "WishLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
