using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public class EMSContext : DbContext
    {
        public EMSContext()
        {            
        }
        public EMSContext(DbContextOptions<EMSContext> options) : base(options)
        {
        }

        public DbSet<Person> Employees { get; set; }

        public DbSet<Department> Departments {get; set;}
    }
}