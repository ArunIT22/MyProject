using MyProject.Models;
using MyProject.ViewModels;

namespace MyProject.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        IEnumerable<Department> GetDepartments();

        EmployeeAndDepartmentViewModel GetEmployee(int id);

        Employee Get(int id);

        Employee Create(Employee employee);

        Employee Update(Employee employee);

        Employee Delete(int id);
    }
}
