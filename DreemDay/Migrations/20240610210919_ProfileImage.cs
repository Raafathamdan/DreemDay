using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreemDay.Migrations
{
    /// <inheritdoc />
    public partial class ProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Phone_Format",
                table: "ServiceProviders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 319, DateTimeKind.Local).AddTicks(6644),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 246, DateTimeKind.Local).AddTicks(9121));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Services",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 322, DateTimeKind.Local).AddTicks(9422),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 249, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ServiceProviders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 323, DateTimeKind.Local).AddTicks(1486),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 249, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 318, DateTimeKind.Local).AddTicks(2064),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 245, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Logins",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 322, DateTimeKind.Local).AddTicks(6223),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 249, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 322, DateTimeKind.Local).AddTicks(4588),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 248, DateTimeKind.Local).AddTicks(8790));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 246, DateTimeKind.Local).AddTicks(9121),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 319, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Services",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 249, DateTimeKind.Local).AddTicks(1971),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 322, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ServiceProviders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 249, DateTimeKind.Local).AddTicks(3605),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 323, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 245, DateTimeKind.Local).AddTicks(8886),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 318, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Logins",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 249, DateTimeKind.Local).AddTicks(98),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 322, DateTimeKind.Local).AddTicks(6223));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 11, 0, 6, 38, 248, DateTimeKind.Local).AddTicks(8790),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 11, 0, 9, 19, 322, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.AddCheckConstraint(
                name: "CK_Phone_Format",
                table: "ServiceProviders",
                sql: "Phone LIKE '[0-9]%'");
        }
    }
}
