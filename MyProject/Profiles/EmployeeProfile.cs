using AutoMapper;

namespace MyProject.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeAndDepartmentViewModel>()
                .ForMember(d => d.Department,
                option => option.MapFrom(s => s.Department.DepartmentName))
                .ForMember(d => d.EmployeeId,
                option => option.MapFrom(s => s.Id));


            CreateMap<CreateEmployeeViewModel, Employee>();
        }
    }
}
