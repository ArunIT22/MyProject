
namespace MyProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {Id=1, Name="Anand", Designation="Sales Executive"},
                new Employee {Id=2, Name="Praveen", Designation="Marketing Executive"},
                new Employee {Id=3, Name="Kannan", Designation="Manager"},
                new Employee {Id=4, Name="Jameel", Designation="System Admin"},
            };
        }
    }
}
