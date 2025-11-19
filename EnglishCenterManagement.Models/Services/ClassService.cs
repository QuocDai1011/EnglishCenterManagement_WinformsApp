using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories;

namespace EnglishCenterManagement.Models.Services
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

        public Class GetById(int id)
        {
            return _classRepository.GetById(id);
        }

        public void Create(Class entity)
        {
            _classRepository.Create(entity);
        }

        public void Update(Class entity)
        {
            _classRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _classRepository.Delete(id);
        }
    }
}
