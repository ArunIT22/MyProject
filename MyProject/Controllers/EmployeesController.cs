using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            var employees = new Employee().GetEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employees = new Employee().GetEmployees();
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
            return View(employee);
        }
    }
}
