using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories.Interfaces;
using EnglishCenterManagement.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        public TeacherService (ITeacherRepository teacherRepository)
        {
            _repository = teacherRepository;
        }

        public Teacher GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int Update(int id, Teacher teacher)
        {
            return _repository.Update(id, teacher);
        }
    }
}
