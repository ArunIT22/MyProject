using Microsoft.EntityFrameworkCore;

namespace MyProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                 new Department { Id = 1, DepartmentName = "Sales" },
            new Department { Id = 2, DepartmentName = "Marketing" },
            new Department { Id = 3, DepartmentName = "Purchase" }
                );
        }
    }
}
