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
            //Shadow Properties of Employee
            modelBuilder.Entity<Employee>()
                .Property<DateTime>("CreatedDate")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Employee>()
                .Property<DateTime?>("ModifiedDate")
                .IsRequired(false);

            modelBuilder.Entity<Department>(b =>
            {
                b.HasAlternateKey(a => a.DepartmentName);
            });

            modelBuilder.Entity<Department>().HasData(
                 new Department { Id = 1, DepartmentName = "Sales" },
            new Department { Id = 2, DepartmentName = "Marketing" },
            new Department { Id = 3, DepartmentName = "Purchase" }
                );
        }     
    }
}
