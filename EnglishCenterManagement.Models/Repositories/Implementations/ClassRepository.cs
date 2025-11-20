using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories.Interfaces;

public class ClassRepository : IClassRepository
{
    private readonly EnglishCenterDbContext _context;

    public ClassRepository(EnglishCenterDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Class> GetAll()
        => _context.Classes.ToList();

    public Class GetById(int id)
    {
        Class cl = _context.Classes.Find(id);
        if(cl == null)
        {
            throw new KeyNotFoundException("Class not found");
        }
        return cl;
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
        var cls = _context.Classes.Find(id);
        if (cls != null)
        {
            _context.Classes.Remove(cls);
            _context.SaveChanges();
        }
    }
}
