using System.ComponentModel.DataAnnotations;

namespace FictionalCustomer.Core.Entitites
{
    public class Project
    {

        public Project()
        {
            ProjectMembers = new List<Employee>();
        }

        [Key]
        public Guid Id { get; set; }


        [Display(Name = "Project")]
        public string? ProjectName { get; set; }

       
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

