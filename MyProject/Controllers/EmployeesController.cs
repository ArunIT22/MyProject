using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Repositories;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            return View(employee);
        }

        //public IActionResult TwoTables()
        //{
        //    var vm = new TwoTablesVM()
        //    {
        //        Employees = new Employee().GetEmployees(),
        //        Departments = new Department().GetDepartments()
        //    };
        //    return View(vm);
        //}

        public IActionResult Create()
        {
            var departments = _employeeRepository.GetDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee
                {
                    Name = employee.Name,
                    DepartmentId = employee.DepartmentId,
                    Designation = employee.Designation,
                    EmailId = employee.EmailId,
                };
                _employeeRepository.Create(emp);
                 return RedirectToAction("Index");
            }
            var departments = _employeeRepository.GetDepartments();
            ViewBag.Departments = departments;
            return View(employee);
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
