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
    new Student(
        userName: "nguyenvana",
        password: "123456",
        fullName: "Nguyễn Văn A",
        email: "vana@gmail.com",
        gender: true,
        address: "TP.HCM",
        dateOfBirth: new DateOnly(2004, 5, 10),
        phoneNumber: "0911111111",
        phoneNumberOfParents: "0981111111",
        createAt: DateTime.Now,
        updateAt: DateTime.Now,
        isActive: true
    )
    {
        StudentId = -1
    },

    new Student(
        userName: "tranthib",
        password: "123456",
        fullName: "Trần Thị B",
        email: "thib@gmail.com",
        gender: false,
        address: "Đồng Nai",
        dateOfBirth: new DateOnly(2003, 8, 25),
        phoneNumber: "0912222222",
        phoneNumberOfParents: "0982222222",
        createAt: DateTime.Now,
        updateAt: DateTime.Now,
        isActive: true
    )
    {
        StudentId = -2
    },

    new Student(
        userName: "levanc",
        password: "123456",
        fullName: "Lê Văn C",
        email: "vanc@gmail.com",
        gender: true,
        address: "Bình Dương",
        dateOfBirth: new DateOnly(2004, 1, 17),
        phoneNumber: "0913333333",
        phoneNumberOfParents: "0983333333",
        createAt: DateTime.Now,
        updateAt: DateTime.Now,
        isActive: true
    )
    {
        StudentId = -3
    }
);



        }
    }
}
