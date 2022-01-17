#nullable disable
using FictionalCustomer.Core.Entitites;
using FictionalCustomer.WebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FictionalCustomer.WebApp.Pages.Admin.Employees
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}
