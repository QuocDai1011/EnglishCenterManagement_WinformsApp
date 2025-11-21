
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string DiscountType { get; set; } = string.Empty;
        public decimal DicountValue { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }


        // -------- FOREIGN KEY ----------

        // khóa ngoại N - 1 student
        public Student Student { get; set; } = new Student();

        //khóa ngoại với course
        public Course Course { get; set; } = new Course();

        // Foreign key 1-1 with receipt
        public Receipt Receipt { get; set; }
    }
}
