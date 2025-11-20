using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    internal class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool Gender { get; set; }
        public string Address { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsSuper {  get; set; }
        public bool IsStudentManager { get; set; }
        public bool IsTeacherManager { get; set; }
    }
}
