using AutoMapper;
using FictionalCustomer.Core.Entitites;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FictionalCustomer.WebApp.Models.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                .ForMember(x => x.EmployeeStatus, op => op.MapFrom(x => x.EmployeeStatus.GetType().GetMember(x.EmployeeStatus.ToString()).First().GetCustomAttribute<DisplayAttribute>()!.GetName()));


            CreateMap<Project, ProjectModel>()
                .ForMember(x => x.StartDate, opt => opt.MapFrom(x => x.StartDate.ToString("yyyy-MM-dd")))
                .ForMember(x => x.EndDate, opt => opt.MapFrom(x => x.EndDate.ToString("yyyy-MM-dd")))
                .ForMember(x => x.ProjectBudget, opt => opt.MapFrom(x => $"{x.ProjectBudget}$"));

        }
    }
}
