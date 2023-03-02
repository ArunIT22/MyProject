using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    [Index(propertyNames:"EmailId", IsUnique =true)]
    public class Employee
    {
        public int Id { get; set; }        
        public string Name { get; set; }
       
        public string Designation { get; set; }

        [Required]
        public string EmailId { get; set; }

        //Table Reference
        public Department Department { get; set; }

        //Foreign Key
        public int DepartmentId { get; set; }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {Id=1, Name="Anand", Designation="Sales Executive", DepartmentId=1},
                new Employee {Id=2, Name="Praveen", Designation="Marketing Executive", DepartmentId=2},
                new Employee {Id=3, Name="Kannan", Designation="Manager", DepartmentId = 3},
                new Employee {Id=4, Name="Jameel", Designation="System Admin", DepartmentId = 1},
            };
        }
    }
}
