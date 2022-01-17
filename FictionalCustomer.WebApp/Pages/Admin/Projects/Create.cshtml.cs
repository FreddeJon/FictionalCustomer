#nullable disable
using FictionalCustomer.Core.Entitites;
using FictionalCustomer.WebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FictionalCustomer.WebApp.Pages.Admin.Projects
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;


        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            GetEmployees();
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        [BindProperty]
        public List<Guid> ProjectMemberIds { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                GetEmployees();
                return Page();
            }

            ProjectMemberIds.ForEach(e => Project.ProjectMembers.Add(_context.Employees.Find(e)));

            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        private void GetEmployees()
        {
            var employees = _context.Employees.OrderBy(e => e.FirstName).Select(s => new
            {
                EmployeeId = s.Id,
                EmployeeName = $"{s.FirstName} {s.LastName} ({s.StackType})"
            }).ToList();
            ViewData["Employees"] = new MultiSelectList(employees, "EmployeeId", "EmployeeName");
        }
    }
}
