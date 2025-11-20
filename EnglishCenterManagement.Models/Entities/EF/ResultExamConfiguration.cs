using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ResultExamConfiguration : IEntityTypeConfiguration<ResultExam>
    {
        public void Configure(EntityTypeBuilder<ResultExam> builder)
        {
            builder.ToTable("result_exam");

            builder.HasKey(r => r.ResultExamId);

            builder.Property(r => r.ResultExamId)
                .ValueGeneratedOnAdd()
                .HasColumnName("result_exam_id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer");


            builder.Property(r => r.StudentId)
                .HasColumnName("student_id")
                .HasColumnType("integer");

            builder.Property(e => e.ResultListening)
                .HasColumnName("result_listening")
                .HasColumnType("float");

            builder.Property(e => e.ResultReading)
                .HasColumnName("result_reading")
                .HasColumnType("float");

            builder.Property(e => e.ResultWriting)
                .HasColumnName("result_writing")
                .HasColumnType("float");

            builder.Property(e => e.ResultSpeaking)
                .HasColumnName("result_speaking")
                .HasColumnType("float");

            // 🔹 Quan hệ 1 - N với Student
            builder.HasOne(r => r.Student)
                   .WithMany(s => s.ResultExams)
                   .HasForeignKey(r => r.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Quan hệ 1 - N với ExamType
            builder.HasOne(r => r.ExamType)
                   .WithMany(e => e.ResultExams)
                   .HasForeignKey(r => r.ExamTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
