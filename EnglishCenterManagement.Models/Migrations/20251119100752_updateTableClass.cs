using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishCenterManagement.Models.Migrations
{
    /// <inheritdoc />
    public partial class updateTableClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "path_image",
                table: "class",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 1,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 19, 17, 7, 49, 605, DateTimeKind.Local).AddTicks(7883), new DateTime(2025, 11, 19, 17, 7, 49, 605, DateTimeKind.Local).AddTicks(7902) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 2,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 19, 17, 7, 49, 605, DateTimeKind.Local).AddTicks(7908), new DateTime(2025, 11, 19, 17, 7, 49, 605, DateTimeKind.Local).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 3,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 19, 17, 7, 49, 605, DateTimeKind.Local).AddTicks(7915), new DateTime(2025, 11, 19, 17, 7, 49, 605, DateTimeKind.Local).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 19, 17, 7, 49, 611, DateTimeKind.Local).AddTicks(6092), new DateTime(2025, 11, 19, 17, 7, 49, 611, DateTimeKind.Local).AddTicks(6111) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 19, 17, 7, 49, 611, DateTimeKind.Local).AddTicks(6117), new DateTime(2025, 11, 19, 17, 7, 49, 611, DateTimeKind.Local).AddTicks(6118) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 19, 17, 7, 49, 611, DateTimeKind.Local).AddTicks(6126), new DateTime(2025, 11, 19, 17, 7, 49, 611, DateTimeKind.Local).AddTicks(6127) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path_image",
                table: "class");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 1,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7036), new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 2,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7057), new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7058) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 3,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7061), new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7062) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6565), new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6584) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6587), new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6588) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6593), new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6594) });
        }
    }
}
