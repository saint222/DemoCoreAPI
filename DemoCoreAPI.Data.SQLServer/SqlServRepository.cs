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
        public SqlServRepository(APIContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            _context = context;
        }
        public IQueryable<T> GeAll()
        {
            return _context.Set<T>();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public void Add(T entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
           _context.Set<T>().Add(entry);
        }
        public void Update(T entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            _context.Set<T>().Update(entry);
        }

        public void Remove(T entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            _context.Set<T>().Remove(entry);
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
