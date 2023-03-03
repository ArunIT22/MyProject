using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Repositories;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.Get(id);
            //EmployeeAndDepartmentViewModel vm = new EmployeeAndDepartmentViewModel
            //{
            //    EmployeeId = employee.Id,
            //    Department = employee.Department.DepartmentName,
            //    Designation = employee.Designation,
            //    EmailId = employee.EmailId,
            //    Name = employee.Name
            //};
            var vm = _mapper.Map<EmployeeAndDepartmentViewModel>(employee);

            return View(vm);
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
        public IActionResult Create(CreateEmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                //Employee emp = new Employee
                //{
                //    Name = employeeVM.Name,
                //    DepartmentId = employeeVM.DepartmentId,
                //    Designation = employeeVM.Designation,
                //    EmailId = employeeVM.EmailId,
                //};

                var emp = _mapper.Map<Employee>(employeeVM);
                _employeeRepository.Create(emp);
                 return RedirectToAction("Index");
            }
            var departments = _employeeRepository.GetDepartments();
            ViewBag.Departments = departments;
            return View(employeeVM);
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
