using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class Class
    {
        public int ClassId { get; set; }                 // PK
        public string ClassCode { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int MaxStudent { get; set; }
        public int CurrentStudent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Shift { get; set; }
        public bool Status { get; set; }
        public string? Note { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? OnlineMeetingLink { get; set; }

        // 1-N with TeacherClass
        public ICollection<TeacherClass> TeacherClasses { get; set; } = new List<TeacherClass>();

        // 1-N with ClassCourse
        public ICollection<ClassCourse> ClassCourses { get; set; } = new List<ClassCourse>();

        // 1-N with StudentClass
        public ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

        // 1-N with StudentAttendance
        public ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

        // 1-N TeacherAttendance
        public ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();

    }
}
