using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            // đặt tên bảng
            builder.ToTable("admins");

            // teacher id
            builder.HasKey(e => e.AdminId);
            builder.Property(e => e.AdminId)
                .HasColumnName("admin_id")
                .ValueGeneratedOnAdd();

            //user name
            builder.Property(e => e.UserName)
                .HasColumnName("user_name")
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");
            builder.HasIndex(e => e.UserName).IsUnique();

            // password
            builder.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(255)");

            // full name
            builder.Property(e => e.FullName)
                .IsRequired()
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255)
                .HasColumnName("full_name");

            // email
            builder.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            //gender
            builder.Property(e => e.Gender)
                .HasColumnName("gender")
                .HasColumnType("bit");

            //address
            builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasMaxLength(255)
                .HasColumnType("nvarchar(255)");

            //date of birth
            builder.Property(e => e.DateOfBirth)
                .HasColumnName("date_of_birth")
                .HasColumnType("date");

            //phone number
            builder.Property(e => e.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            //salary
            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("salary");

            //create at
            builder.Property(e => e.CreateAt)
                .HasColumnName("create_at")
                .HasColumnType("date");

            //update at
            builder.Property(e => e.UpdateAt)
                .HasColumnName("update_at")
                .HasColumnType("date");

            // is active
            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasColumnType("bit");

            // is super
            builder.Property(e => e.IsSuper)
                .HasColumnName("is_super")
                .HasColumnType("bit");

            // is student manager
            builder.Property(e => e.IsStudentManager)
                .HasColumnName("is_student_manager")
                .HasColumnType("bit");

            // is teacher manager
            builder.Property(e => e.IsTeacherManager)
                .HasColumnName("is_teacher_manager")
                .HasColumnType("bit");
        }
    }
}
