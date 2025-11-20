using EnglishCenterManagement.Models.Entities;
using System.Collections.Generic;

namespace EnglishCenterManagement.Models.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetAllStudentsByClassId(int classId);
        Student GetById(int id);

        string Create(Student student);
        string Update(Student student);
        void Delete(int id);

    }
}
