using DataAccessEF.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEF.Repositories;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    protected readonly MedicalPlusDbContext _dbContext;

    public GenericRepo(MedicalPlusDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual Task<List<T>> GetAll()
    {
        return _dbContext.Set<T>().ToListAsync();
    }

    public ValueTask<T?> GetById(int id)
    {
        return _dbContext.Set<T>().FindAsync(id);
    }

    public void Add(T item)
    {
        _dbContext.Set<T>().Add(item);
    }

    public void Delete(int id)
    {
        var item = _dbContext.Set<T>().Find(id);
        if (item != null) 
            _dbContext.Set<T>().Remove(item);
    }

    public void Update(T item)
    {
        _dbContext.Set<T>().Update(item);
    }
}