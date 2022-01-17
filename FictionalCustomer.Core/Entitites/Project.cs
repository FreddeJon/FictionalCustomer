using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FictionalCustomer.Core.Entitites
{
    [Table("Projects")]
    public class Project
    {

        public Project()
        {
            ProjectMembers = new List<Employee>();
        }

        [Key]
        public Guid Id { get; set; }


        [Display(Name = "Project Title")]
        public string? ProjectName { get; set; }


        [Display(Name = "Project Description")]
        [Column(TypeName = "ntext")]
        public string? ProjectDescription { get; set; }

        [Display(Name = "Customer / Company")]
        public string? Company { get; set; }

        [Display(Name = "Budget")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProjectBudget { get; set; }

        [Display(Name = "Status")]
        public ProjectStatus ProjectStatus { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Project Members")]
        public IList<Employee>? ProjectMembers { get; set; }
    }
}

