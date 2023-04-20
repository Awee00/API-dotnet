using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class RoleRepository : IRoleRepository
{
    private readonly MyContext _context;
    public RoleRepository(MyContext context)
    {
        _context = context;
    }
    public IEnumerable<Role> GetAll()
    {
        return _context.Set<Role>().ToList();
    }
    public Role? GetById(int id)
    {
        return _context.Set<Role>().Find(id);
    }
    public int Insert(Role role)
    {
        _context.Set<Role>().Add(role);
        return _context.SaveChanges();
    }
    public int Update(Role role)
    {
        _context.Set<Role>().Update(role);
        return _context.SaveChanges();
    }
    public int Delete(int id)
    {
        var role = GetById(id);
        if (role == null)
            return 0;
        _context.Set<Role>().Remove(role);
        return _context.SaveChanges();
    }
}
