using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class ClassCourse
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }

        // Navigation properties
        public Class Class { get; set; } = new Class();
        public Course Course { get; set; } = new Course();
    }
}
