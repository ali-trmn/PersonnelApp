using Microsoft.EntityFrameworkCore;
using PersonnelApp.Data.Configurations;
using PersonnelApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=TORAMAN; Initial Catalog=PersonnelAppDb; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PersonnelConfiguration());
        }
    }
}
