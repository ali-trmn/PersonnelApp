using Microsoft.EntityFrameworkCore;
using PersonnelApp.Data.Contexts;
using PersonnelApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private DataContext _dataContext { get; set; }

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>();
        }

        public void Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _dataContext.Set<T>().Where(predicate).First();
        }
    }
}
