
using Loginnmodels2.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IApplicationRepository<T> : IDisposable
{
    IQueryable<T> Get();

    T Get(Guid id);

    void Create(T record);

    void Update(T record);

    void Delete(Guid id);

    int Save();

    Task<int> SaveAsync();
    Task<T> GetAsync(Guid id);
}

public class ApplicationRepository<T> : IApplicationRepository<T> where T : class, IAppEntity
{
    private DbContext _context;

    public ApplicationRepository(dbcontext1 context)
    {
        _context = context;
    }

    public IQueryable<T> Get()
    {
        return _context.Set<T>().Where(e => !e.IsDeleted);
    }

    public T Get(Guid id)
    {
        return Get().SingleOrDefault(e => e.Id == id);
    }

    public async Task<T> GetAsync(Guid id)
    {
        return await Get().SingleOrDefaultAsync(e => e.Id == id);
    }

    public void Create(T record)
    {
        record.CreatedOn = DateTime.Now;
        record.ModifiedOn = record.CreatedOn;
        _context.Add(record);
    }

    public void Update(T record)
    {
        record.ModifiedOn = DateTime.Now;
        _context.Set<T>().Attach(record);
        _context.Entry(record).State = EntityState.Modified;
    }

    public void Delete(Guid id)
    {
        var record = Get(id);

        if (record != null)
        {
            record.ModifiedOn = DateTime.Now;
            record.IsDeleted = true;
        }
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    #region Dispose
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
    #endregion
}