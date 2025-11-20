using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class EnglishCenterDbContext : DbContext
    {
        public EnglishCenterDbContext() { }
        //Constructor nhận DbContextOptions
        public EnglishCenterDbContext(DbContextOptions<EnglishCenterDbContext> options)
            : base(options)
        {
        }

        // Các DbSet tương ứng với entity
        DbSet<Admin> Admins { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassCourse> ClassCourses { get; set; }
        DbSet<CommuneDistrict> CommuneDistricts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<ExpertiseTeacher> ExpertiseTeachers { get; set; }
        DbSet<ProvinceCity> ProvinceCities { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ResultExam> ResultExams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentExercise> StudentExercises { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAttendance> TeacherAttendances { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=DESKTOP-9N554RA\\SQLEXPRESS;" +
                    "Database=english_center_management_dev;" +
                    "Trusted_Connection=True;" +
                    "TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Áp dụng tất cả cấu hình trong assembly hiện tại
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnglishCenterDbContext).Assembly);

        }

    }
    
}
