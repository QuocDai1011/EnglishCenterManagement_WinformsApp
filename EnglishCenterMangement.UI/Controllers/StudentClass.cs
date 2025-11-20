using EnglishCenterManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnglishCenterManagement.UI.Controllers
{
    public class Student_Class {
        private readonly EnglishCenterDbContext _context;
        public Student_Class()
        {
            _context = new EnglishCenterDbContext();
        }

        public List<Class> Get(int id)
        {
            var classes = _context.StudentClasses
                .Include(c => c.Class)
                .Where(c => c.StudentId == id)
                .Select(c => c.Class)
                .ToList();

            return classes;
        }
    }

}
