using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Required]
        [StringLength(maximumLength:30)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        [Display(Name = "Phone Number (Optional)")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Adress")]
        public string? Email { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        public string? SSN { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        public string? Address { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        public string? City { get; set; }

        [Required]
        [Display(Name = "Stack")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Status")]
        public EmployeeStatus EmployeeStatus { get; set; }
        public IList<Project>? Projects { get; set; }


        public string GetName() => $"{FirstName} {LastName}";
    }
}
