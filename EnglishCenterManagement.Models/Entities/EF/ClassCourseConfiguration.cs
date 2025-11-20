using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ClassCourseConfiguration : IEntityTypeConfiguration<ClassCourse>
    {
        public void Configure(EntityTypeBuilder<ClassCourse> builder)
        {
            builder.ToTable("class_course");

            // Khóa chính tổng hợp
            builder.HasKey(cc => new { cc.ClassId, cc.CourseId });

            // Cấu hình cột
            builder.Property(cc => cc.ClassId)
                   .HasColumnName("class_id")
                   .IsRequired();

            builder.Property(cc => cc.CourseId)
                   .HasColumnName("course_id")
                   .IsRequired();

            // Quan hệ với Class
            builder.HasOne(cc => cc.Class)
                   .WithMany(c => c.ClassCourses)
                   .HasForeignKey(cc => cc.ClassId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ với Course
            builder.HasOne(cc => cc.Course)
                   .WithMany(c => c.ClassCourses)
                   .HasForeignKey(cc => cc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
