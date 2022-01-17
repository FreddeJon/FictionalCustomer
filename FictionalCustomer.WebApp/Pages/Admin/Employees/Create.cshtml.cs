#nullable disable
using FictionalCustomer.Core.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FictionalCustomer.WebApp.Pages.Admin.Employees
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly FictionalCustomer.WebApp.Data.ApplicationDbContext _context;

        public CreateModel(FictionalCustomer.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Employee.EmployeeStatus = EmployeeStatus.Employeed;
            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
