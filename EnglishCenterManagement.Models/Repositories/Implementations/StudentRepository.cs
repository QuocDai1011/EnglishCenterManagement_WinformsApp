using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EnglishCenterManagement.Models.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EnglishCenterDbContext _context;

        public StudentRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public string Create(Student entity)
        {
            try
            {
                _context.Students.Add(entity);
                _context.SaveChanges();
                return null; // null nghĩa là không lỗi
            }
            catch (DbUpdateException ex)
            {
                // Lấy lỗi SQL gốc
                var inner = ex.InnerException?.Message ?? ex.Message;

                // Trả lỗi lên Service
                return inner;
            }
            catch (Exception ex)
            {
                // Các lỗi khác
                return ex.Message;
            }
        }


        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Student> getAllStudentByClassId(int classId)
        {
            return _context.StudentClasses
                           .Where(sc => sc.ClassId == classId)
                           .Select(sc => sc.Student)
                           .ToList();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public Student getStudentByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public string Update(Student entity)
        {
            try
            {
                _context.Students.Update(entity);
                _context.SaveChanges();
                return null; // null nghĩa là không lỗi
            }
            catch (DbUpdateException ex)
            {
                // Lấy lỗi SQL gốc
                var inner = ex.InnerException?.Message ?? ex.Message;

                // Trả lỗi lên Service
                return inner;
            }
            catch (Exception ex)
            {
                // Các lỗi khác
                return ex.Message;
            }
        }
    }
}
