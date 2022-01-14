using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FictionalCustomer.Core.Entitites
{
    public enum EmployeeStatus
    {
        [Display(Name = "Employeed")]
        Employeed,
        [Display(Name = "On Vacation")]
        Vacation,
        [Display(Name = "Former Employee")]
        FormerEmployee
    }
}
