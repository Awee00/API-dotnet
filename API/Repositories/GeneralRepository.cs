using API.Context;
using API.Models;

namespace API.Repositories;

public class GeneralRepository<TEntity, TKey, TContext> : IGeneralRepository<TEntity, TKey>
    where TEntity : class
    where TContext : MyContext
{
    protected readonly TContext _context;

    public GeneralRepository(TContext context)
    {
        _context = context;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public TEntity? GetByKey(TKey key)
    {
        return _context.Set<TEntity>().Find(key);
    }

    public int Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        return _context.SaveChanges();
    }

    public int Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        return _context.SaveChanges();
    }

    public int Delete(TKey key)
    {
        var entity = GetByKey(key);
        if (entity == null)
            return 0;
        _context.Set<TEntity>().Remove(entity);
        return _context.SaveChanges();
    }
}
