using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class CouseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("course");

            builder.HasKey(e => e.CourseId);
            builder.Property(e => e.CourseId)
                .ValueGeneratedOnAdd()
                .HasColumnName("course_id")
                .HasColumnType("integer");

            builder.Property(e => e.CourseCode)
                .HasColumnName("course_code")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);

            builder.Property(e => e.CourseName)
                .HasColumnName("course_name")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);

            builder.Property(e => e.TutitionFee)
                .HasColumnName("tutition_fee")
                .HasColumnType("decimal(18, 3)");

            builder.Property(e => e.NumberSessions)
                .HasColumnName("number_sessions");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(255)
                .HasColumnType("nvarchar(255)");

            builder.Property(e => e.level)
                .HasColumnName("level")
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.CreateAt)
                .HasColumnName("create_at");

            builder.Property(e => e.UpdateAt)
                .HasColumnName("update_at");

            builder.Property(e => e.AvatarLink)
                .HasColumnName("avatar_link")
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
        }
    }
}
