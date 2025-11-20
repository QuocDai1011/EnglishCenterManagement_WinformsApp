using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class Exercise
    {
        [Key]
        [Column("exercise_id")]
        public int ExerciseId { get; set; }

        [Column("teacher_id")]
        public int TeacherId { get; set; }

        [Column("topic")]
        [MaxLength(255)]
        public string Topic { get; set; } = string.Empty;

        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        [Column("suggest")]
        [MaxLength(255)]
        public string Suggest { get; set; } = string.Empty;

        [Column("image_link")]
        [MaxLength(255)]
        public string ImageLink { get; set; } = string.Empty;

        [Column("note")]
        [MaxLength(255)]
        public string Note { get; set; } = string.Empty;

        // 🔹 Quan hệ N–1 với Teacher
        public Teacher Teacher { get; set; } = new Teacher();

        // 1-N StudentExercise
        public ICollection<StudentExercise> StudentExercises { get; set; } = new List<StudentExercise>();
    }
}
