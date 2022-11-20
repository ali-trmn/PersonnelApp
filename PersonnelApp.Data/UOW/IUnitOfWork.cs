using PersonnelApp.Data.Repository;
using PersonnelApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Data.UOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> user { get; }
        IGenericRepository<Personnel> personnel { get; }
        IGenericRepository<Role> role { get; }

        int SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
