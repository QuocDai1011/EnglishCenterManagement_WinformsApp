using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities.EF
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
           

            // đặt tên bảng
            builder.ToTable("students");

            // student id
            builder.HasKey(e => e.StudentId);
            builder.Property(e => e.StudentId)
                .HasColumnName("student_id")
                .ValueGeneratedOnAdd();

            //user name
            builder.Property(e => e.UserName)
                .HasColumnName("user_name")
                .HasColumnType("varchar(100)");
            builder.HasIndex(e => e.UserName).IsUnique();

            // password
            builder.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasColumnType("varchar(255)");

            // full name
            builder.Property(e => e.FullName)
                .IsRequired()
                .HasColumnType("nvarchar(255)")
                .HasColumnName("full_name");

            // email
            builder.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasColumnType("varchar(255)");

            //gender
            builder.Property(e => e.Gender)
                .HasColumnName("gender")
                .HasColumnType("bit");

            //address
            builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasColumnType("nvarchar(255)");

            //date of birth
            builder.Property(e => e.DateOfBirth)
                .HasColumnName("date_of_birth")
                .HasColumnType("date");

            //phone number
            builder.Property(e => e.PhoneNumber)
                .HasColumnName("phone_number")
                .HasColumnType("varchar(10)");

            //phone number of parents
            builder.Property(e => e.PhoneNumberOfParents)
                .IsRequired()
                .HasColumnType("varchar(10)")
                .HasColumnName("phone_number_of_parents");

            //creat at
            builder.Property(e => e.CreateAt)
                .HasColumnType("date")
                .HasColumnName("creat_at");

            //update at
            builder.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("update_at");

            // is active
            builder.Property(e => e.IsActive)
                .HasColumnType("bit")
                .HasColumnName("is_active");

            //======= SeedData ========
            _ = builder.HasData(
                new Student { StudentId = 1, UserName = "nguyenvana", Password = "123456", FullName = "Nguyễn Văn A", Email = "vana@gmail.com", Gender = true, Address = "TP.HCM", DateOfBirth = new DateOnly(2004, 5, 10), PhoneNumber = "0911111111", PhoneNumberOfParents = "0981111111", CreateAt = DateTime.Now, UpdateAt = DateTime.Now, IsActive = true },
                new Student { StudentId = 2, UserName = "tranthib", Password = "123456", FullName = "Trần Thị B", Email = "thib@gmail.com", Gender = false, Address = "Đồng Nai", DateOfBirth = new DateOnly(2003, 8, 25), PhoneNumber = "0912222222", PhoneNumberOfParents = "0982222222", CreateAt = DateTime.Now, UpdateAt = DateTime.Now, IsActive = true },
                new Student { StudentId = 3, UserName = "levanc", Password = "123456", FullName = "Lê Văn C", Email = "vanc@gmail.com", Gender = true, Address = "Bình Dương", DateOfBirth = new DateOnly(2004, 1, 17), PhoneNumber = "0913333333", PhoneNumberOfParents = "0983333333", CreateAt = DateTime.Now, UpdateAt = DateTime.Now, IsActive = true }
                
            );

        }
    }
}
