using EnglishCenterManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishCenterManagement.UI.Controllers
{
    public class StudentController
    {
        private readonly EnglishCenterDbContext _context;

        public StudentController()
        {
            _context = new EnglishCenterDbContext();
        }

        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == id);
        }

    }
}
