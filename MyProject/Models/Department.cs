using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "varchar")]
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
