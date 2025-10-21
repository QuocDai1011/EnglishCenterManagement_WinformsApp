using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> builder)
        {
            builder.ToTable("teacher_course");

            builder.HasKey(e => new {e.TeacherId, e.CourseId});

            builder.Property(e => e.TeacherId)
                .IsRequired()
                .HasColumnName("teacher_id");

            builder.Property(e => e.CourseId)
                .IsRequired()
                .HasColumnName("course_id");

            // N-1 with teacher
            builder.HasOne(e => e.Teacher)
                .WithMany(ec => ec.TeacherCourses)
                .HasForeignKey(e => e.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            // N-1 with Course
            builder.HasOne(e => e.Course)
                .WithMany(ec => ec.TeacherCourses)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
