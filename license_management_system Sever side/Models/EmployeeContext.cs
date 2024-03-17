using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
