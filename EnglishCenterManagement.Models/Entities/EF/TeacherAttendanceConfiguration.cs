using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class TeacherAttendanceConfiguration : IEntityTypeConfiguration<TeacherAttendance>
    {
        public void Configure(EntityTypeBuilder<TeacherAttendance> builder)
        {
            builder.ToTable("teacher_attendance");

            // 🔹 Khóa chính
            builder.HasKey(ta => ta.TeacherAttendanceId);

            builder.Property(ta => ta.TeacherAttendanceId)
                   .HasColumnName("teacher_attendance_id")
                   .ValueGeneratedOnAdd();

            // 🔹 Thuộc tính cơ bản
            builder.Property(ta => ta.TeacherId)
                   .HasColumnName("teacher_id")
                   .IsRequired();

            builder.Property(ta => ta.ClassId)
                   .HasColumnName("class_id")
                   .IsRequired();

            builder.Property(ta => ta.AttendanceDate)
                   .HasColumnName("attendance_date")
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(ta => ta.CheckInTime)
                   .HasColumnName("check_in_time")
                   .HasColumnType("time");

            builder.Property(ta => ta.CreateAt)
                   .HasColumnName("create_at")
                   .HasColumnType("date");

            builder.Property(ta => ta.UpdateAt)
                   .HasColumnName("update_at")
                   .HasColumnType("date");

            builder.Property(ta => ta.Note)
                   .HasColumnName("note")
                   .HasColumnType("text");

            // 🔹 Quan hệ với Teacher
            builder.HasOne(ta => ta.Teacher)
                   .WithMany(t => t.TeacherAttendances)
                   .HasForeignKey(ta => ta.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Quan hệ với Class
            builder.HasOne(ta => ta.Class)
                   .WithMany(c => c.TeacherAttendances)
                   .HasForeignKey(ta => ta.ClassId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
