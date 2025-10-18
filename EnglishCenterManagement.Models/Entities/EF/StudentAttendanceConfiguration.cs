using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class StudentAttendanceConfiguration : IEntityTypeConfiguration<StudentAttendance>
    {
        public void Configure(EntityTypeBuilder<StudentAttendance> builder)
        {
            builder.ToTable("student_attendance");

            // 🔹 Khóa chính
            builder.HasKey(sa => sa.StudentAttendanceId);

            builder.Property(sa => sa.StudentAttendanceId)
                   .HasColumnName("student_attendance_id")
                   .ValueGeneratedOnAdd();

            // 🔹 Các cột dữ liệu
            builder.Property(sa => sa.StudentId)
                   .HasColumnName("student_id")
                   .IsRequired();

            builder.Property(sa => sa.ClassId)
                   .HasColumnName("class_id")
                   .IsRequired();

            builder.Property(sa => sa.AttendanceDate)
                   .HasColumnName("attendance_date")
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(sa => sa.CheckInTime)
                   .HasColumnName("check_in_time")
                   .HasColumnType("time");

            builder.Property(sa => sa.CreateAt)
                   .HasColumnName("create_at")
                   .HasColumnType("date");

            builder.Property(sa => sa.UpdateAt)
                   .HasColumnName("update_at")
                   .HasColumnType("date");

            builder.Property(sa => sa.Note)
                   .HasColumnName("note")
                   .HasColumnType("text");

            // 🔹 Quan hệ với Student
            builder.HasOne(sa => sa.Student)
                   .WithMany(s => s.StudentAttendances)
                   .HasForeignKey(sa => sa.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Quan hệ với Class
            builder.HasOne(sa => sa.Class)
                   .WithMany(c => c.StudentAttendances)
                   .HasForeignKey(sa => sa.ClassId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
