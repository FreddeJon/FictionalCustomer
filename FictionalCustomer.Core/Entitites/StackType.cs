using System.ComponentModel.DataAnnotations;

namespace FictionalCustomer.Core.Entitites
{
    public enum StackType
    {
        [Display(Name = "Back-End Developer")]
        BackEnd,

        [Display(Name = "Front-End Developer")]
        FrontEnd,

        [Display(Name = "Full Stack Developer")]
        FullStack,

        [Display(Name = "Mobile Developer")]
        Mobile,

        [Display(Name = "UX Designer")]
        UX
    }
}
