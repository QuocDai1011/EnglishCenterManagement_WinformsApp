using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class TeacherCourse
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        // ---------- navigation --------------
        // with teacher
        public Teacher Teacher { get; set; } = new Teacher();

        //with course
        public Course Course { get; set; } = new Course();
    }
}
