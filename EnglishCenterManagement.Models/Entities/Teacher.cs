using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool Gender { get; set; }
        public string Address { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public bool IsActive { get; set; }

        // 1-N expertise
        public ICollection<ExpertiseTeacher> expertiseTeachers { get; set; }

        // 1-N TeacherCourse
        public ICollection<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();

        // 1-N TeacherClass
        public ICollection<TeacherClass> TeacherClasses { get; set; } = new List<TeacherClass>();

        // 1-N Exercise
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

        // 1-N TeacherAttendance
        public ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();


    }
}
