using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class ExpertiseTeacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Key]
        public int ExpertiseID { get; set; } = 0;


        // Navigation
        public Teacher Teacher { get; set; }
        public Expertise Expertise { get; set; }
    }
}
