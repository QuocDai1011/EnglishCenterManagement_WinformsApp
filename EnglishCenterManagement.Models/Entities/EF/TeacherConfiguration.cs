using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // đặt tên bảng
            builder.ToTable("teachers");

            // teacher id
            builder.HasKey(e => e.TeacherID);
            builder.Property(e => e.TeacherID)
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
                .HasMaxLength (255)
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
                .HasColumnType("bit")
                .HasColumnName("is_active");

            // ✅ Seed dữ liệu mẫu
            builder.HasData(
                new Teacher
                {
                    TeacherID = 1,
                    UserName = "nguyenvana",
                    Password = "123456",
                    FullName = "Nguyễn Văn A",
                    Email = "nguyenvana@example.com",
                    Gender = true,
                    Address = "Hà Nội",
                    DateOfBirth = new DateOnly(1990, 5, 12),
                    PhoneNumber = "0912345678",
                    Salary = 15000000m,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    IsActive = true
                },
                new Teacher
                {
                    TeacherID = 2,
                    UserName = "tranthib",
                    Password = "abcdef",
                    FullName = "Trần Thị B",
                    Email = "tranthib@example.com",
                    Gender = false,
                    Address = "TP.HCM",
                    DateOfBirth = new DateOnly(1993, 8, 20),
                    PhoneNumber = "0987654321",
                    Salary = 18000000m,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    IsActive = true
                },
                new Teacher
                {
                    TeacherID = 3,
                    UserName = "lequangc",
                    Password = "qwerty",
                    FullName = "Lê Quang C",
                    Email = "lequangc@example.com",
                    Gender = true,
                    Address = "Đà Nẵng",
                    DateOfBirth = new DateOnly(1988, 2, 15),
                    PhoneNumber = "0978123456",
                    Salary = 20000000m,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
