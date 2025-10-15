using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ExpertiseTeacherConfiguration : IEntityTypeConfiguration<ExpertiseTeacher>
    {
        public void Configure(EntityTypeBuilder<ExpertiseTeacher> builder)
        {
            builder.ToTable("expertise_teacher");

            builder.HasKey(e => new { e.TeacherId, e.ExpertiseID });

            builder.Property(e => e.TeacherId)
                .IsRequired()
                .HasColumnName("teacher_id")
                .HasColumnType("integer");

            builder.Property(e => e.ExpertiseID)
                .IsRequired()
                .HasColumnName("expertise_id")
                .HasColumnType("integer");

            builder.HasOne(e => e.Teacher)
                .WithMany(t => t.expertiseTeachers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.TeacherId);

            builder.HasOne(e => e.Expertise)
                .WithMany(t => t.ExpertiseTeachers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.ExpertiseID);
        }
    }
}
