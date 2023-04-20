using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class EducationRepository : IEducationRepository
{
    private readonly MyContext _context;
    public EducationRepository(MyContext context)
    {
        _context = context;
    }

    public IEnumerable<Education> GetAll()
    {
        return _context.Set<Education>().ToList();
    }

    public Education? GetById(int id)
    {
        return _context.Set<Education>().Find(id);
    }

    public int Insert(Education education)
    {
        _context.Set<Education>().Add(education);
        return _context.SaveChanges();
    }

    public int Update(Education education)
    {
        _context.Set<Education>().Update(education);
        return _context.SaveChanges();
    }

    public int Delete(int id)
    {
        var education = GetById(id);
        if (education == null)
            return 0;
        _context.Set<Education>().Remove(education);
        return _context.SaveChanges();
    }
}
