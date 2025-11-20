using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public decimal TutitionFee { get; set; }
        public int NumberSessions { get; set; }
        public string Description { get; set; }
        public string level { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string AvatarLink { get; set; }


        // ======= Foreign Key =========
        //Khóa ngoại 1-N với student course
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        // 1-N with TeacherCourse
        public ICollection<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();

        // 1-N with ClassCourse
        public ICollection<ClassCourse> ClassCourses { get; set; } = new List<ClassCourse>();
    }
}
