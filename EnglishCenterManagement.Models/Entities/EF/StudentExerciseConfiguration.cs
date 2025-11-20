using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class StudentExerciseConfiguration : IEntityTypeConfiguration<StudentExercise>
    {
        public void Configure(EntityTypeBuilder<StudentExercise> builder)
        {
            builder.ToTable("student_exercise");

            // Khóa chính tổng hợp (Composite Primary Key)
            builder.HasKey(se => new { se.StudentId, se.ExerciseId });

            // Cấu hình cột
            builder.Property(se => se.AnswerLink)
                   .HasColumnName("answer_link")
                   .HasColumnType("text");

            builder.Property(se => se.Description)
                   .HasColumnName("description")
                   .HasColumnType("text");

            builder.Property(se => se.Score)
                   .HasColumnName("score")
                   .HasColumnType("float");

            builder.Property(se => se.CommentOfTeacher)
                   .HasColumnName("comment_of_teacher")
                   .HasColumnType("text");

            builder.Property(se => se.CommentPrivateOfStudent)
                   .HasColumnName("comment_private_of_student")
                   .HasColumnType("text");

            builder.Property(se => se.Note)
                   .HasColumnName("note")
                   .HasColumnType("text");

            // Quan hệ với Student
            builder.HasOne(se => se.Student)
                   .WithMany(s => s.StudentExercises)
                   .HasForeignKey(se => se.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ với Exercise
            builder.HasOne(se => se.Exercise)
                   .WithMany(e => e.StudentExercises)
                   .HasForeignKey(se => se.ExerciseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
   
}
