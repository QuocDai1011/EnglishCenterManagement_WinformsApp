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
    public class CourseRepository : ICourseRepository
    {
        private readonly EnglishCenterDbContext _context;

        public CourseRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public Course GetCourseByIdClass(int classId)
        {
            var course = _context.ClassCourses
                .Where(c => c.ClassId == classId)
                .Select(c => c.Course)
                .FirstOrDefault();

            if (course == null)
                return null;

            return course;
        }
    }
}
