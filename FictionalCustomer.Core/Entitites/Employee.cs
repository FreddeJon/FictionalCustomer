using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FictionalCustomer.Core.Entitites
{

    [Table(name: "Employees")]
    public class Employee
    {
        public Employee()
        {
            Projects = new List<Project>();
        }

        [Key]
        public Guid Id { get; set; }


        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Email Address")]
        public string? Email { get; set; }


        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "Street Address")]
        public string? Street { get; set; }

        [Display(Name = "Stack")]
        public StackType StackType { get; set; }

        [Display(Name = "Status")]
        public EmployeeStatus EmployeeStatus { get; set; }

        public IList<Project>? Projects { get; set; }

        public string GetFullName() => $"{FirstName} {LastName} ({StackType})";
    }
}
