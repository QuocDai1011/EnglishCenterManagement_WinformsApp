using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool Gender { get; set; }
        public string Address { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string PhoneNumberOfParents { get; set; } = string.Empty;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; }

        //khóa ngoại 1-N với result exam
        public ICollection<ResultExam> ResultExams { get; set; } = new List<ResultExam>();
        //Khóa ngoại 1-N với student course
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        // 1-N StudentExercise
        public ICollection<StudentExercise> StudentExercises { get; set; } = new List<StudentExercise>();

        // 1-N with StudentClass
        public ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

        // 1-N with StudentAttendance
        public ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

        public Student(
              string userName, string password,
            string fullName, string email, bool gender, string address,
            DateOnly? dateOfBirth, string phoneNumber, string phoneNumberOfParents,
            DateTime? createAt, DateTime? updateAt, bool isActive
            )
        {
            UserName = userName;
            Password = password;
            FullName = fullName;
            Email = email;
            Gender = gender;
            Address = address;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            PhoneNumberOfParents = phoneNumberOfParents;
            CreateAt = createAt;
            UpdateAt = updateAt;
            IsActive = isActive;
        }

        public Student()
        {
        }
    }
}
