using DemoCoreAPI.Data.Errors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DemoCoreAPI.Data.SQLServer
{
    public class SqlServRepository<T> : IRepository<T> where T : class
    {
        private readonly APIContext _context;
        private readonly DbSet<T> _dbSet;
        public SqlServRepository(APIContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            _context = context;
            _dbSet = context.Set<T>();
        }
        public T FindById(long id)
        {
            return _dbSet.Find(id);
        }
        public IQueryable<T> GeAll()
        {
            return _dbSet.AsNoTracking();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public void Add(T entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            _dbSet.Add(entry);
        }
        public void Update(T entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            _dbSet.Update(entry);
        }

        public void Remove(T entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            _dbSet.Remove(entry);
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Exception occured while working with the Db", ex);
            }
        }        
    }
}
