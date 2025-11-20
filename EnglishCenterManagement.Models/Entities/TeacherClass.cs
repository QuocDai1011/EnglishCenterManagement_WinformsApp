using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class TeacherClass
    {
        public int TeacherId { get; set; }
        public int ClassId { get; set; }

        // foreign key
        public Teacher Teacher { get; set; } = new Teacher();
        public Class Class { get; set; } = new Class();
        
    }
}
