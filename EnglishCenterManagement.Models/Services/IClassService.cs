using EnglishCenterManagement.Models.Entities;

namespace EnglishCenterManagement.Models.Services
{
    public interface IClassService
    {
        IEnumerable<Class> GetAllClasses();
        Class GetById(int id);
        void Create(Class entity);
        void Update(Class entity);
        void Delete(int id);
    }
}
