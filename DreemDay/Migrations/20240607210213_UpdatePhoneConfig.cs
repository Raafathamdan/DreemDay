using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreemDay.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhoneConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Phone_Format1",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 396, DateTimeKind.Local).AddTicks(9819),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 227, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Services",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 400, DateTimeKind.Local).AddTicks(4523),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 229, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ServiceProviders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 400, DateTimeKind.Local).AddTicks(7458),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 230, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 395, DateTimeKind.Local).AddTicks(193),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 227, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Logins",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 400, DateTimeKind.Local).AddTicks(1437),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 229, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 399, DateTimeKind.Local).AddTicks(9297),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 229, DateTimeKind.Local).AddTicks(6375));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 227, DateTimeKind.Local).AddTicks(9377),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 396, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Services",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 229, DateTimeKind.Local).AddTicks(9129),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 400, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ServiceProviders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 230, DateTimeKind.Local).AddTicks(551),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 400, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 227, DateTimeKind.Local).AddTicks(904),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 395, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Logins",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 229, DateTimeKind.Local).AddTicks(7529),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 400, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 7, 23, 54, 55, 229, DateTimeKind.Local).AddTicks(6375),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 8, 0, 2, 13, 399, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.AddCheckConstraint(
                name: "CK_Phone_Format1",
                table: "Users",
                sql: "Phone LIKE '[0-9]%'");
        }
    }
}
