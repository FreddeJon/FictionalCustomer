#nullable disable
using FictionalCustomer.Core.Entitites;
using FictionalCustomer.WebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FictionalCustomer.WebApp.Pages.Admin.Projects
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get; set; }

        public async Task OnGetAsync()
        {
            Project = await _context.Projects.ToListAsync();
        }
    }
}
