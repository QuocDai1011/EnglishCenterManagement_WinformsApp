using EnglishCenterManagement.Models.Entities;

namespace EnglishCenterManagement.Models.Services.Interfaces
{
    public interface IClassService
    {
        IEnumerable<Class> GetAllClasses();
        Class GetClassById(int id);
        void CreateClass(Class entity);
        string UpdateClass(Class entity);
        void DeleteClass(int id);
    }
}
