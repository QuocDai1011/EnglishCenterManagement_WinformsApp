using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("exercise");

            // 🔑 Primary key
            builder.HasKey(e => e.ExerciseId);

            builder.Property(e => e.ExerciseId)
                   .HasColumnName("exercise_id")
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.TeacherId)
                   .HasColumnName("teacher_id")
                   .IsRequired();

            builder.Property(e => e.Topic)
                   .HasColumnName("topic")
                   .HasColumnType("nvarchar(255)")
                   .HasMaxLength(255);

            builder.Property(e => e.Description)
                   .HasColumnName("description")
                   .HasColumnType("nvarchar(255)")
                   .HasMaxLength(255);

            builder.Property(e => e.Suggest)
                   .HasColumnName("suggest")
                   .HasColumnType("nvarchar(255)")
                   .HasMaxLength(255);

            builder.Property(e => e.ImageLink)
                   .HasColumnName("image_link")
                   .HasColumnType("varchar(255)")
                   .HasMaxLength(255);

            builder.Property(e => e.Note)
                   .HasColumnName("note")
                   .HasColumnType("varchar(255)")
                   .HasMaxLength(255);

            // 🔹 Quan hệ N–1: Một Teacher có nhiều Exercise
            builder.HasOne(e => e.Teacher)
                   .WithMany(t => t.Exercises)
                   .HasForeignKey(e => e.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
