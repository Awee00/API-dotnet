using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly MyContext _context;
    public EmployeeRepository(MyContext context)
    {
        _context = context;
    }
    public IEnumerable<Employee> GetAll()
    {
        return _context.Set<Employee>().ToList();
    }
    public Employee? GetById(string id)
    {
        return _context.Set<Employee>().Find(id);
    }
    public int Insert(Employee employee)
    {
        _context.Set<Employee>().Add(employee);
        return _context.SaveChanges();
    }
    public int Update(Employee employee)
    {
        _context.Set<Employee>().Update(employee);
        return _context.SaveChanges();
    }
    public int Delete(string id)
    {
        var employee = GetById(id);
        if (employee == null)
            return 0;
        _context.Set<Employee>().Remove(employee);
        return _context.SaveChanges();
    }
}
