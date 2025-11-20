using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Repositories.Implementations
{
    public class ClassRepository : IClassRepository
    {
        private readonly EnglishCenterDbContext _context;

        public ClassRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public List<Class> GetClassByIdTeacher(int teacherId)
        {
            var classes = _context.TeacherClasses
                .Include(c => c.Teacher)
                .Where(c => c.TeacherId == teacherId)
                .Select(c => c.Class)
                .ToList();

            return classes;
        }
    }
}
