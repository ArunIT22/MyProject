namespace MyProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee Create(Employee employee)
        {
            if (employee != null)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;
            }
            return null;
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            var employee = _context.Employees.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public EmployeeAndDepartmentViewModel GetEmployee(int id)
        {
            var employee = _context.Employees.ToList();
            var department = _context.Departments.ToList();

            var data = (from emp in employee
                        join dep in department on emp.DepartmentId equals dep.Id
                        select new EmployeeAndDepartmentViewModel
                        {
                            Name = emp.Name,
                            Designation = emp.Designation,
                            EmployeeId = emp.Id,
                            Department = dep.DepartmentName,
                            EmailId = emp.EmailId
                        }).FirstOrDefault(x => x.EmployeeId == id);
            return data;

        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
