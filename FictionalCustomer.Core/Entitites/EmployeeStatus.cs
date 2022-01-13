using System.ComponentModel.DataAnnotations;

namespace FictionalCustomer.Core.Entitites
{
    public enum EmployeeStatus
    {
        [Display(Name = "Employeed")]
        Employeed,
        [Display(Name = "On Vacation")]
        OnVacation,
        [Display(Name = "Former Employee")]
        FormerEmployee
    }
}
