using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class UniversityRepository : IUniversityRepository
{
    private readonly MyContext _context;
    public UniversityRepository(MyContext context)
    {
        _context = context;
    }
    public IEnumerable<University> GetAll()
    {
        return _context.Set<University>().ToList();
    }

    public University? GetById(int id)
    {
        return _context.Set<University>().Find(id);
    }

    public int Insert(University university)
    {
        _context.Set<University>().Add(university);
        return _context.SaveChanges();
    }

    public int Update(University university)
    {
        _context.Set<University>().Update(university);
        return _context.SaveChanges();
    }
    public int Delete(int id)
    {
        var university = GetById(id);
        if (university == null)
            return 0;
        _context.Set<University>().Remove(university);
        return _context.SaveChanges();
    }
}
