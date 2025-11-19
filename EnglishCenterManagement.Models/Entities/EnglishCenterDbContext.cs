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
        //Constructor nhận DbContextOptions
        public EnglishCenterDbContext(DbContextOptions<EnglishCenterDbContext> options)
            : base(options)
        {
        }

        // Các DbSet tương ứng với entity
        DbSet<Admin> Admins { get; set; }
        public DbSet<Class> Classes { get; set; }
        DbSet<ClassCourse> ClassCourses { get; set; }
        DbSet<CommuneDistrict> CommuneDistricts { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<ExamType> ExamTypes { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<Expertise> Expertises { get; set; }
        DbSet<ExpertiseTeacher> ExpertiseTeachers { get; set; }
        DbSet<ProvinceCity> ProvinceCities { get; set; }
        DbSet<Receipt> Receipts { get; set; }
        DbSet<ResultExam> ResultExams { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentAttendance> StudentAttendances { get; set; }
        DbSet<StudentClass> StudentClasses { get; set; }
        DbSet<StudentCourse> StudentCourses { get; set; }
        DbSet<StudentExercise> StudentExercises { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<TeacherAttendance> TeacherAttendances { get; set; }
        DbSet<TeacherClass> TeacherClasses { get; set; }
        DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Áp dụng tất cả cấu hình trong assembly hiện tại
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnglishCenterDbContext).Assembly);

        }

    }
    
}
