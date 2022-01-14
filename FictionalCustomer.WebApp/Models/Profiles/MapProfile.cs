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

        }
    }
}
