using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class ExamType
    {
        [Key]
        public int ExamTypeId { get; set; } 

        public string ExamTypeName { get; set; } = string.Empty;

        public string ExamTypeCode { get; set; } = string.Empty;

        //Khóa ngoại 1-N với ResultExam
        public ICollection<ResultExam> ResultExams { get; set; } = new List<ResultExam>();

    }
}
