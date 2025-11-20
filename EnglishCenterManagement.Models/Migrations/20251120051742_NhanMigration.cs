using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishCenterManagement.Models.Migrations
{
    /// <inheritdoc />
    public partial class NhanMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 1,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 20, 12, 17, 41, 882, DateTimeKind.Local).AddTicks(7616), new DateTime(2025, 11, 20, 12, 17, 41, 882, DateTimeKind.Local).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 2,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 20, 12, 17, 41, 882, DateTimeKind.Local).AddTicks(7632), new DateTime(2025, 11, 20, 12, 17, 41, 882, DateTimeKind.Local).AddTicks(7632) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 3,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 20, 12, 17, 41, 882, DateTimeKind.Local).AddTicks(7635), new DateTime(2025, 11, 20, 12, 17, 41, 882, DateTimeKind.Local).AddTicks(7636) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 20, 12, 17, 41, 884, DateTimeKind.Local).AddTicks(6350), new DateTime(2025, 11, 20, 12, 17, 41, 884, DateTimeKind.Local).AddTicks(6354) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 20, 12, 17, 41, 884, DateTimeKind.Local).AddTicks(6358), new DateTime(2025, 11, 20, 12, 17, 41, 884, DateTimeKind.Local).AddTicks(6359) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 11, 20, 12, 17, 41, 884, DateTimeKind.Local).AddTicks(6362), new DateTime(2025, 11, 20, 12, 17, 41, 884, DateTimeKind.Local).AddTicks(6362) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 1,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 17, 3, 7, 781, DateTimeKind.Local).AddTicks(8753), new DateTime(2025, 10, 15, 17, 3, 7, 781, DateTimeKind.Local).AddTicks(8771) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 2,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 17, 3, 7, 781, DateTimeKind.Local).AddTicks(8775), new DateTime(2025, 10, 15, 17, 3, 7, 781, DateTimeKind.Local).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 3,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 17, 3, 7, 781, DateTimeKind.Local).AddTicks(8779), new DateTime(2025, 10, 15, 17, 3, 7, 781, DateTimeKind.Local).AddTicks(8779) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 1,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9600), new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 2,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9606), new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9607) });

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 3,
                columns: new[] { "create_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9610), new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9610) });
        }
    }
}
