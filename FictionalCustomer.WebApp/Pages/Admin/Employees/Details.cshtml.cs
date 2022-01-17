#nullable disable
using FictionalCustomer.Core.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FictionalCustomer.WebApp.Pages.Admin.Employees
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly FictionalCustomer.WebApp.Data.ApplicationDbContext _context;

        public DetailsModel(FictionalCustomer.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees.Include(e => e.Projects).FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
