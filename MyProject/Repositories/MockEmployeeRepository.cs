using MyProject.Models;
using MyProject.ViewModels;

namespace MyProject.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>
            {
                 new Employee {Id=1, Name="Anand", Designation="Sales Executive", DepartmentId=1},
                new Employee {Id=2, Name="Praveen", Designation="Marketing Executive", DepartmentId=2},
                new Employee {Id=3, Name="Kannan", Designation="Manager", DepartmentId = 3},
                new Employee {Id=4, Name="Jameel", Designation="System Admin", DepartmentId = 1},
            };

        }

        public Employee Create(Employee employee)
        {
            _employees.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return new Department().GetDepartments();
        }

        public EmployeeAndDepartment GetEmployee(int id)
        {
            var employees = _employees;
            var departments = new Department().GetDepartments();

            var vm = from emp in employees
                     join dep in departments on emp.DepartmentId equals dep.Id
                     select new EmployeeAndDepartment
                     {
                         EmployeeId = emp.Id,
                         Name = emp.Name,
                         Designation = emp.Designation,
                         Department = dep.DepartmentName
                     };

            var employee = vm.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
