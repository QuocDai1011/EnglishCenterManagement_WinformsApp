using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class StudentClassConfiguration : IEntityTypeConfiguration<StudentClass>
    {
        public void Configure(EntityTypeBuilder<StudentClass> builder)
        {
            builder.ToTable("student_class");

            // Khóa chính tổng hợp
            builder.HasKey(sc => new { sc.StudentId, sc.ClassId });

            // Cấu hình cột
            builder.Property(sc => sc.StudentId)
                   .HasColumnName("student_id")
                   .IsRequired();

            builder.Property(sc => sc.ClassId)
                   .HasColumnName("class_id")
                   .IsRequired();

            // Thiết lập quan hệ
            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.StudentClasses)
                   .HasForeignKey(sc => sc.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sc => sc.Class)
                   .WithMany(c => c.StudentClasses)
                   .HasForeignKey(sc => sc.ClassId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
   
}
