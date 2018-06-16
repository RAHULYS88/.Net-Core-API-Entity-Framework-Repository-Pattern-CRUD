using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeServices.Models
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<Employee> employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().ToTable("Employee");
        }
    }
}
