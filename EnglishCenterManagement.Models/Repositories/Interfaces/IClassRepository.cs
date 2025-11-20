using EnglishCenterManagement.Models.Entities;

namespace EnglishCenterManagement.Models.Repositories.Interfaces
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAll();
        Class GetById(int id);
        void Create(Class entity);
        void Update(Class entity);
        void Delete(int id);
    }
}
