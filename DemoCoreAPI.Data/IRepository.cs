using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DemoCoreAPI.Data
{
    public interface IRepository<T> where T: class 
    { 
        T FindById(long id);
        IQueryable<T> GeAll();
        IQueryable<T> Where (Expression<Func<T, bool>> predicate);
        void Add(T entry);
        void Update(T entry);
        void Remove(T entity);
        int SaveChanges();
    }
}
