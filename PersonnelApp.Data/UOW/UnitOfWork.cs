using Microsoft.EntityFrameworkCore.Storage;
using PersonnelApp.Data.Contexts;
using PersonnelApp.Data.Repository;
using PersonnelApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork()
        {
            _dataContext = new DataContext();
        }

        private GenericRepository<User> _user { get; set; }
        private GenericRepository<Personnel> _personnel { get; set; }
        private GenericRepository<Role> _role { get; set; }

        public IGenericRepository<User> user => _user ?? new GenericRepository<User>(_dataContext);

        public IGenericRepository<Personnel> personnel => _personnel ?? new GenericRepository<Personnel>(_dataContext);
        public IGenericRepository<Role> role => _role ?? new GenericRepository<Role>(_dataContext);

        public void BeginTransaction()
        {
            if(_transaction == null)
            {
                _transaction = _dataContext.Database.BeginTransaction();
            }
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public int SaveChanges()
        {
           return _dataContext.SaveChanges();
        }
    }
}
