using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class StudentExercise
    {
        public int StudentId { get; set; }
        public int ExerciseId { get; set; }

        public string? AnswerLink { get; set; }
        public string? Description { get; set; }
        public float? Score { get; set; }
        public string? CommentOfTeacher { get; set; }
        public string? CommentPrivateOfStudent { get; set; }
        public string? Note { get; set; }

        // Navigation properties
        public Student Student { get; set; } = new Student();
        public Exercise Exercise { get; set; } = new Exercise();
    }
}
