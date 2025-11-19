using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("class");

            // 🔑 Primary key
            builder.HasKey(c => c.ClassId);

            builder.Property(c => c.ClassId)
                   .HasColumnName("class_id")
                   .ValueGeneratedOnAdd();

            // 🧾 Columns
            builder.Property(c => c.ClassCode)
                   .HasColumnName("class_code")
                   .HasColumnType("varchar(20)")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(c => c.ClassName)
                   .HasColumnName("class_name")
                   .HasColumnType("nvarchar(255)")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(c => c.MaxStudent)
                   .HasColumnName("max_student");

            builder.Property(c => c.CurrentStudent)
                   .HasColumnName("current_student");

            builder.Property(c => c.StartDate)
                   .HasColumnName("start_date")
                   .HasColumnType("date");

            builder.Property(c => c.EndDate)
                   .HasColumnName("end_date")
                   .HasColumnType("date");

            builder.Property(c => c.Shift)
                   .HasColumnName("shift");

            builder.Property(c => c.Status)
                   .HasColumnName("status")
                   .HasColumnType("bit");

            builder.Property(c => c.Note)
                   .HasColumnName("note")
                   .HasColumnType("nvarchar(255)")
                   .HasMaxLength(255);

            builder.Property(c => c.CreateAt)
                   .HasColumnName("create_at")
                   .HasColumnType("date");

            builder.Property(c => c.UpdateAt)
                   .HasColumnName("update_at")
                   .HasColumnType("date");

            builder.Property(c => c.OnlineMeetingLink)
                   .HasColumnName("online_meeting_link")
                   .HasColumnType("text")
                   .HasMaxLength(1000);

            builder.Property(c => c.pathImage)
                .HasColumnName("path_image")
                .HasColumnType("TEXT");
        }
    }
}
