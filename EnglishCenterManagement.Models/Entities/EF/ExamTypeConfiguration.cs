using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ExamTypeConfiguration : IEntityTypeConfiguration<ExamType>
    {
        public void Configure(EntityTypeBuilder<ExamType> builder)
        {
            builder.ToTable("exam_type");

            builder.HasKey(e => e.ExamTypeId);
            builder.Property(e => e.ExamTypeId).ValueGeneratedOnAdd();

            builder.Property(e => e.ExamTypeName)
                .IsRequired()
                .HasColumnName("exam_result_name")
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);

            builder.Property (e => e.ExamTypeCode)
                .IsRequired()
                .HasColumnName("exam_result_code")
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);
        }
    }
}
