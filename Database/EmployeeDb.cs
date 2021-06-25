using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDatabase.Database
{
    public class EmployeeDb:DbContext
    {
        public EmployeeDb(DbContextOptions<EmployeeDb> context) : base(context) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
