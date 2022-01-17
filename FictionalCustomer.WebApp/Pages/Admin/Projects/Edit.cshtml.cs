#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FictionalCustomer.Core.Entitites;
using FictionalCustomer.WebApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace FictionalCustomer.WebApp.Pages.Admin.Projects
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        [BindProperty]
        public List<Guid> ProjectMemberIds { get; set; } = new List<Guid>();
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects.AsNoTracking().Include(p => p.ProjectMembers).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);


            Project.ProjectMembers.ToList().ForEach(e => ProjectMemberIds.Add(e.Id));

            if (Project == null)
            {
                return NotFound();
            }
            GetEmployees();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                GetEmployees();
                return Page();
            }
            //_context.Attach(projectToUpdate).State = EntityState.Modified;
            var projectToUpdate = await _context.Projects.Include(m => m.ProjectMembers).FirstOrDefaultAsync(p => p.Id == Project.Id);

            if (projectToUpdate == null) return RedirectToPage("/Error");


            var originalMembers = projectToUpdate.ProjectMembers.ToList();


            _context.Entry(projectToUpdate).CurrentValues.SetValues(Project);

            projectToUpdate.ProjectMembers.Clear();

            ProjectMemberIds.ForEach(e => projectToUpdate.ProjectMembers.Add(_context.Employees.Find(e)));

         


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

        private bool ProjectExists(Guid id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
