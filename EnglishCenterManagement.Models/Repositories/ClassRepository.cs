using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories;
using Microsoft.EntityFrameworkCore;

public class ClassRepository : IClassRepository
{
    private readonly EnglishCenterDbContext _context;

    public ClassRepository(EnglishCenterDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Class> GetAll()
    {
        return _context.Classes.ToList();
    }

    public Class GetById(int id)
    {
        return _context.Classes.Find(id);
    }

    public void Create(Class entity)
    {
        _context.Classes.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Class entity)
    {
        _context.Classes.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var item = _context.Classes.Find(id);
        if (item != null)
        {
            _context.Classes.Remove(item);
            _context.SaveChanges();
        }
    }
}
