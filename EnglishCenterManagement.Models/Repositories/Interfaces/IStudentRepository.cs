using EnglishCenterManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetById(int id);
        string Create(Student entity);
        string Update(Student entity);
        void Delete(int id);

        IEnumerable<Student> getAllStudentByClassId(int classId);

        Student getStudentByUserName(string username);

    }
}
