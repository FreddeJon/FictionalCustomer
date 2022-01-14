using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FictionalCustomer.WebApp.Models
{
    public class ProjectModel
    {
        public Guid Id { get; set; }

        public string? ProjectName { get; set; }

        public string? ProjectDescription { get; set; }

        public string? Company { get; set; }
        public string? ProjectBudget { get; set; }
        public string? ProjectStatus { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

    }
}
