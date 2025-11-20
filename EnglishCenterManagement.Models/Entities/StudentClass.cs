using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class StudentClass
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        // Navigation properties
        public Student Student { get; set; } = new Student();
        public Class Class { get; set; } = new Class();
    }
}
