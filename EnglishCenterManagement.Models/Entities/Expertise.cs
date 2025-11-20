using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class Expertise
    {
        [Key]
        public int ExpertiseId { get; set; }
        public string ExpertiseName { get; set; } = string.Empty;

        // 1-N expertise_teacher
        public ICollection<ExpertiseTeacher> ExpertiseTeachers { get; set; }
    }
}
