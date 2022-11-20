using PersonnelApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Data.Repository
{
    public interface IGenericRepository<T> where T : class,IEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Func<T, bool> predicate);
        IQueryable<T> GetAll();
    }
}
