using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; // online or offline
        public string Status { get; set; } = string.Empty; // not_yet_paid of paid

        public int StudentId { get; set; }
        public int CourseId { get; set; }


        // ========= Foreign key ========== 
        // navigation student_course
        public StudentCourse StudentCourse { get; set; } = null!;
    }
}
