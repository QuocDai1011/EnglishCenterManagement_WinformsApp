using EnglishCenterManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EnglishCenterManagement.UI.Controllers
{
    public class CourseController
    {
        private readonly EnglishCenterDbContext _context;

        public CourseController()
        {
            _context = new EnglishCenterDbContext();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }
    }
}
