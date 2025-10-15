using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("receipt");

            builder.HasKey(r => r.ReceiptId);

            builder.Property(r => r.ReceiptId)
                   .HasColumnName("receipt_id")
                   .ValueGeneratedOnAdd();

            builder.Property(r => r.Amount)
                   .HasColumnType("decimal(18,3)");

            builder.Property(r => r.PaymentDate)
                   .HasColumnName("payment_date");

            builder.Property(r => r.PaymentMethod)
                   .HasColumnName("payment_method")
                   .HasColumnType("varchar(10)");

            builder.Property(r => r.Status)
                   .HasColumnName("status")
                   .HasColumnType("varchar(20)");

            // 🔹 Quan hệ 1–1 với StudentCourse
            builder.HasOne(r => r.StudentCourse)
               .WithOne(sc => sc.Receipt)
               .HasForeignKey<Receipt>(r => new { r.StudentId, r.CourseId })
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.StudentId).HasColumnName("student_id");
            builder.Property(r => r.CourseId).HasColumnName("course_id");
        }
    }
}
