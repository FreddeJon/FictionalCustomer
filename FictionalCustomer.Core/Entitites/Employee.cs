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

        [StringLength(maximumLength:30)]
        public string? FirstName { get; set; }
        [StringLength(maximumLength: 30)]
        public string? LastName { get; set; }
        [StringLength(maximumLength: 30)]
        public string? SSN { get; set; }
        [StringLength(maximumLength: 30)]
        public string? Address { get; set; }

        [StringLength(maximumLength: 30)]
        public string? City { get; set; }

        public EmployeeType EmployeeType { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public IList<Project>? Projects { get; set; }
    }
}
