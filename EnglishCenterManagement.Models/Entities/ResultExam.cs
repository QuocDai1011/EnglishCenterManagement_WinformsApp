using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class ResultExam
    {
        [Key]
        public int ResultExamId { get; set; }
        public float ResultListening {  get; set; }
        public float ResultReading { get; set; }
        public float ResultWriting { get; set; }
        public float ResultSpeaking { get; set; }

        // Khóa ngoại đến Student
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        // Khóa ngoại đến ExamType
        public int ExamTypeId { get; set; }

        [ForeignKey(nameof(ExamTypeId))]
        public ExamType ExamType { get; set; }

    }
}
