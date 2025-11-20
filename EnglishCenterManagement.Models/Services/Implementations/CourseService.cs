using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly EnglishCenterDbContext _context;

        public CourseService(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            _context.Courses.Remove(GetCourseById(courseId));
            _context.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int courseId)
        {
            Course course = _context.Courses.Find(courseId);

            return course == null ? throw new KeyNotFoundException("Course not found") : course;
        }

        public Course getCourseByStudentId(int studentId)
        {
            Course course = _context.Courses
                .Where(c => c.StudentCourses.Any(sc => sc.StudentId == studentId))
                .FirstOrDefault();

            return course == null ? throw new KeyNotFoundException("Course not found for the given student ID") : course;
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);    
            _context.SaveChanges();
        }
    }
}
