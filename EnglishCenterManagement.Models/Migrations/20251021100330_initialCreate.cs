using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnglishCenterManagement.Models.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    create_at = table.Column<DateTime>(type: "date", nullable: true),
                    update_at = table.Column<DateTime>(type: "date", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_super = table.Column<bool>(type: "bit", nullable: false),
                    is_student_manager = table.Column<bool>(type: "bit", nullable: false),
                    is_teacher_manager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    class_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    max_student = table.Column<int>(type: "int", nullable: false),
                    current_student = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: false),
                    shift = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_at = table.Column<DateTime>(type: "date", nullable: false),
                    update_at = table.Column<DateTime>(type: "date", nullable: false),
                    online_meeting_link = table.Column<string>(type: "text", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.class_id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    course_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tutition_fee = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    number_sessions = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    level = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    avatar_link = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "exam_type",
                columns: table => new
                {
                    ExamTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exam_result_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    exam_result_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam_type", x => x.ExamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "expertise",
                columns: table => new
                {
                    ExpertiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    expertise_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expertise", x => x.ExpertiseId);
                });

            migrationBuilder.CreateTable(
                name: "province_city",
                columns: table => new
                {
                    province_city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    province_city_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province_city", x => x.province_city_id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "varchar(100)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(10)", nullable: false),
                    phone_number_of_parents = table.Column<string>(type: "varchar(10)", nullable: false),
                    creat_at = table.Column<DateTime>(type: "date", nullable: true),
                    update_at = table.Column<DateTime>(type: "date", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 100, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    create_at = table.Column<DateTime>(type: "date", nullable: true),
                    update_at = table.Column<DateTime>(type: "date", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "class_course",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class_course", x => new { x.class_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_class_course_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_class_course_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commune_district",
                columns: table => new
                {
                    commune_district_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commune_district = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    province_city_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commune_district", x => x.commune_district_id);
                    table.ForeignKey(
                        name: "FK_commune_district_province_city_province_city_id",
                        column: x => x.province_city_id,
                        principalTable: "province_city",
                        principalColumn: "province_city_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "result_exam",
                columns: table => new
                {
                    result_exam_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    result_listening = table.Column<double>(type: "float", nullable: false),
                    result_reading = table.Column<double>(type: "float", nullable: false),
                    result_writing = table.Column<double>(type: "float", nullable: false),
                    result_speaking = table.Column<double>(type: "float", nullable: false),
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result_exam", x => x.result_exam_id);
                    table.ForeignKey(
                        name: "FK_result_exam_exam_type_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "exam_type",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_result_exam_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_attendance",
                columns: table => new
                {
                    student_attendance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false),
                    attendance_date = table.Column<DateTime>(type: "date", nullable: false),
                    check_in_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    create_at = table.Column<DateTime>(type: "date", nullable: true),
                    update_at = table.Column<DateTime>(type: "date", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_attendance", x => x.student_attendance_id);
                    table.ForeignKey(
                        name: "FK_student_attendance_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_attendance_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_class",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_class", x => new { x.student_id, x.class_id });
                    table.ForeignKey(
                        name: "FK_student_class_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_class_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_course",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    discount_type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    discount_value = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_course", x => new { x.student_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_student_course_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_course_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exercise",
                columns: table => new
                {
                    exercise_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    topic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    suggest = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    image_link = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    note = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise", x => x.exercise_id);
                    table.ForeignKey(
                        name: "FK_exercise_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "admin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expertise_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    expertise_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expertise_teacher", x => new { x.teacher_id, x.expertise_id });
                    table.ForeignKey(
                        name: "FK_expertise_teacher_expertise_expertise_id",
                        column: x => x.expertise_id,
                        principalTable: "expertise",
                        principalColumn: "ExpertiseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expertise_teacher_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "admin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_attendance",
                columns: table => new
                {
                    teacher_attendance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false),
                    attendance_date = table.Column<DateTime>(type: "date", nullable: false),
                    check_in_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    create_at = table.Column<DateTime>(type: "date", nullable: true),
                    update_at = table.Column<DateTime>(type: "date", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_attendance", x => x.teacher_attendance_id);
                    table.ForeignKey(
                        name: "FK_teacher_attendance_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_attendance_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "admin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_class",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_class", x => new { x.teacher_id, x.class_id });
                    table.ForeignKey(
                        name: "FK_teacher_class_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_class_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "admin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_course",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_course", x => new { x.teacher_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_teacher_course_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_course_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "admin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receipt",
                columns: table => new
                {
                    receipt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    payment_method = table.Column<string>(type: "varchar(10)", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipt", x => x.receipt_id);
                    table.ForeignKey(
                        name: "FK_receipt_student_course_student_id_course_id",
                        columns: x => new { x.student_id, x.course_id },
                        principalTable: "student_course",
                        principalColumns: new[] { "student_id", "course_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_exercise",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    answer_link = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    score = table.Column<double>(type: "float", nullable: true),
                    comment_of_teacher = table.Column<string>(type: "text", nullable: true),
                    comment_private_of_student = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_exercise", x => new { x.StudentId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_student_exercise_exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "exercise",
                        principalColumn: "exercise_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_exercise_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "student_id", "address", "creat_at", "date_of_birth", "email", "full_name", "gender", "is_active", "password", "phone_number", "phone_number_of_parents", "update_at", "user_name" },
                values: new object[,]
                {
                    { 1, "TP.HCM", new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7036), new DateOnly(2004, 5, 10), "vana@gmail.com", "Nguyễn Văn A", true, true, "123456", "0911111111", "0981111111", new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7052), "nguyenvana" },
                    { 2, "Đồng Nai", new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7057), new DateOnly(2003, 8, 25), "thib@gmail.com", "Trần Thị B", false, true, "123456", "0912222222", "0982222222", new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7058), "tranthib" },
                    { 3, "Bình Dương", new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7061), new DateOnly(2004, 1, 17), "vanc@gmail.com", "Lê Văn C", true, true, "123456", "0913333333", "0983333333", new DateTime(2025, 10, 21, 17, 3, 30, 87, DateTimeKind.Local).AddTicks(7062), "levanc" }
                });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "admin_id", "address", "create_at", "date_of_birth", "email", "full_name", "gender", "is_active", "password", "phone_number", "salary", "update_at", "user_name" },
                values: new object[,]
                {
                    { 1, "Hà Nội", new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6565), new DateOnly(1990, 5, 12), "nguyenvana@example.com", "Nguyễn Văn A", true, true, "123456", "0912345678", 15000000m, new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6584), "nguyenvana" },
                    { 2, "TP.HCM", new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6587), new DateOnly(1993, 8, 20), "tranthib@example.com", "Trần Thị B", false, true, "abcdef", "0987654321", 18000000m, new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6588), "tranthib" },
                    { 3, "Đà Nẵng", new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6593), new DateOnly(1988, 2, 15), "lequangc@example.com", "Lê Quang C", true, true, "qwerty", "0978123456", 20000000m, new DateTime(2025, 10, 21, 17, 3, 30, 92, DateTimeKind.Local).AddTicks(6594), "lequangc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_admins_user_name",
                table: "admins",
                column: "user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_class_course_course_id",
                table: "class_course",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_commune_district_province_city_id",
                table: "commune_district",
                column: "province_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_teacher_id",
                table: "exercise",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_expertise_teacher_expertise_id",
                table: "expertise_teacher",
                column: "expertise_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_student_id_course_id",
                table: "receipt",
                columns: new[] { "student_id", "course_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_result_exam_ExamTypeId",
                table: "result_exam",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_result_exam_student_id",
                table: "result_exam",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_attendance_class_id",
                table: "student_attendance",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_attendance_student_id",
                table: "student_attendance",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_class_class_id",
                table: "student_class",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_course_course_id",
                table: "student_course",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_exercise_ExerciseId",
                table: "student_exercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_students_user_name",
                table: "students",
                column: "user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teacher_attendance_class_id",
                table: "teacher_attendance",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_attendance_teacher_id",
                table: "teacher_attendance",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_class_class_id",
                table: "teacher_class",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_course_course_id",
                table: "teacher_course",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_user_name",
                table: "teachers",
                column: "user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "class_course");

            migrationBuilder.DropTable(
                name: "commune_district");

            migrationBuilder.DropTable(
                name: "expertise_teacher");

            migrationBuilder.DropTable(
                name: "receipt");

            migrationBuilder.DropTable(
                name: "result_exam");

            migrationBuilder.DropTable(
                name: "student_attendance");

            migrationBuilder.DropTable(
                name: "student_class");

            migrationBuilder.DropTable(
                name: "student_exercise");

            migrationBuilder.DropTable(
                name: "teacher_attendance");

            migrationBuilder.DropTable(
                name: "teacher_class");

            migrationBuilder.DropTable(
                name: "teacher_course");

            migrationBuilder.DropTable(
                name: "province_city");

            migrationBuilder.DropTable(
                name: "expertise");

            migrationBuilder.DropTable(
                name: "student_course");

            migrationBuilder.DropTable(
                name: "exam_type");

            migrationBuilder.DropTable(
                name: "exercise");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
