using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("student_course");

            builder.HasKey(e => new { e.StudentId, e.CourseId });

            builder.Property(e => e.StudentId)
                .IsRequired()
                .HasColumnName("student_id");

            builder.Property(e => e.CourseId)
                .IsRequired()
                .HasColumnName("course_id");

            builder.Property(e => e.DiscountType)
                .HasColumnName("discount_type")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(e => e.DicountValue)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("discount_value");

            builder.HasOne(sc => sc.Student)           // mỗi StudentCourse thuộc về 1 Student
               .WithMany(s => s.StudentCourses)    // 1 Student có nhiều StudentCourse
               .HasForeignKey(sc => sc.StudentId)  // khóa ngoại
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Course)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
