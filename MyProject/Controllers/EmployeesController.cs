using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            var employees = new Employee().GetEmployees();
            return View(employees);
        }
    }
}
