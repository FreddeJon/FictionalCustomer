using FictionalCustomer.Core.Entitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FictionalCustomer.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Project>? Projects { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FictionalCustomer.Core.Entitites.Employee> Employee { get; set; }



    }
}