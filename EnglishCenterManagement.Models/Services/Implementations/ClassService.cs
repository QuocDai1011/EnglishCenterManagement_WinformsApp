using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories.Interfaces;
using EnglishCenterManagement.Models.Services.Interfaces;

namespace EnglishCenterManagement.Models.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return _classRepository.GetAll();
        }

        public Class GetClassById(int id)
        {
            return _classRepository.GetById(id);
        }

        public void CreateClass(Class entity)
        {
            _classRepository.Create(entity);
        }

        public void UpdateClass(Class entity)
        {
            _classRepository.Update(entity);
        }

        public void DeleteClass(int id)
        {
            _classRepository.Delete(id);
        }
    }
}
