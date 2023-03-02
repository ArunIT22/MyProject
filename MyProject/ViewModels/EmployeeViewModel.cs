namespace MyProject.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }

        [Required]
        public string EmailId { get; set; }
    }
}
