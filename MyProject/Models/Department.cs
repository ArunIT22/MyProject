namespace MyProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public List<Department> GetDepartments()
        {
            return new List<Department>
            {
            new Department { Id=1, DepartmentName="Sales"},
            new Department { Id=2, DepartmentName="Marketing"},
            new Department { Id=3, DepartmentName="Purchase"},
            };
        }
    }
}
