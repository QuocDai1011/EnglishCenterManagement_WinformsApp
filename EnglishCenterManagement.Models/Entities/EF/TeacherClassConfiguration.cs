using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class TeacherClassConfiguration : IEntityTypeConfiguration<TeacherClass>
    {
        public void Configure(EntityTypeBuilder<TeacherClass> builder)
        {
            builder.ToTable("teacher_class");

            // 🔑 Composite Key (khóa chính kép)
            builder.HasKey(tc => new { tc.TeacherId, tc.ClassId });

            // 🔗 Thuộc tính cột
            builder.Property(tc => tc.TeacherId)
                   .HasColumnName("teacher_id")
                   .IsRequired();

            builder.Property(tc => tc.ClassId)
                   .HasColumnName("class_id")
                   .IsRequired();

            // 🧭 Quan hệ N–1 với Teacher
            builder.HasOne(tc => tc.Teacher)
                   .WithMany(t => t.TeacherClasses)     // Một giáo viên có thể dạy nhiều lớp
                   .HasForeignKey(tc => tc.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 🧭 Quan hệ N–1 với Class
            builder.HasOne(tc => tc.Class)
                   .WithMany(c => c.TeacherClasses)     // Một lớp có thể có nhiều giáo viên
                   .HasForeignKey(tc => tc.ClassId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
