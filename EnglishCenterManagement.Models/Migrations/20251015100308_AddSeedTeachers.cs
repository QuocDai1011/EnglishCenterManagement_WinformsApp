using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnglishCenterManagement.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "admin_id", "address", "create_at", "date_of_birth", "email", "full_name", "gender", "is_active", "password", "phone_number", "salary", "update_at", "user_name" },
                values: new object[,]
                {
                    { 1, "Hà Nội", new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9600), new DateOnly(1990, 5, 12), "nguyenvana@example.com", "Nguyễn Văn A", true, true, "123456", "0912345678", 15000000m, new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9603), "nguyenvana" },
                    { 2, "TP.HCM", new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9606), new DateOnly(1993, 8, 20), "tranthib@example.com", "Trần Thị B", false, true, "abcdef", "0987654321", 18000000m, new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9607), "tranthib" },
                    { 3, "Đà Nẵng", new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9610), new DateOnly(1988, 2, 15), "lequangc@example.com", "Lê Quang C", true, true, "qwerty", "0978123456", 20000000m, new DateTime(2025, 10, 15, 17, 3, 7, 783, DateTimeKind.Local).AddTicks(9610), "lequangc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "teachers",
                keyColumn: "admin_id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 1,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 16, 57, 28, 451, DateTimeKind.Local).AddTicks(4164), new DateTime(2025, 10, 15, 16, 57, 28, 451, DateTimeKind.Local).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 2,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 16, 57, 28, 451, DateTimeKind.Local).AddTicks(4183), new DateTime(2025, 10, 15, 16, 57, 28, 451, DateTimeKind.Local).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 3,
                columns: new[] { "creat_at", "update_at" },
                values: new object[] { new DateTime(2025, 10, 15, 16, 57, 28, 451, DateTimeKind.Local).AddTicks(4187), new DateTime(2025, 10, 15, 16, 57, 28, 451, DateTimeKind.Local).AddTicks(4188) });
        }
    }
}
