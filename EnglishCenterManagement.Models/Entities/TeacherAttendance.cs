using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class TeacherAttendance
    {
        public int TeacherAttendanceId { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Note { get; set; }

        // Navigation properties
        public Teacher Teacher { get; set; } = new Teacher();
        public Class Class { get; set; } = new Class();
    }
}
