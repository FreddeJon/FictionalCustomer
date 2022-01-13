using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FictionalCustomer.WebApp.Data
{
    public class SeedAdminAccount
    {
        public static void Initizialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                //context.Database.EnsureCreated();
                //context.Database.Migrate();
                CreateAdminUser(userManager, roleManager, configuration);
            }
        }

        private static void CreateAdminUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var role = "Admin";
            var adminUserName = configuration?["AdminInfo:ADMINUSER"];
            var adminPassword = configuration?["AdminInfo:ADMINPASSWORD"];
            if (string.IsNullOrWhiteSpace(adminUserName) || string.IsNullOrWhiteSpace(adminPassword))
            {
                throw new ArgumentNullException(adminUserName, adminPassword);
            }

            bool foundRole = roleManager.RoleExistsAsync(role).Result;

            if (!foundRole)
            {
                var adminRole = roleManager.CreateAsync(new IdentityRole(role)).GetAwaiter().GetResult();
            }

            var adminUser = userManager.FindByNameAsync(adminUserName).Result;
            if (adminUser is null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminUserName,
                    Email = adminUserName,
                };
                var created = userManager.CreateAsync(adminUser, adminPassword).Result;

                if (created.Succeeded)
                {
                    var confirmationToken = userManager.GenerateEmailConfirmationTokenAsync(adminUser).Result;
                    _ = userManager.ConfirmEmailAsync(adminUser, confirmationToken).Result;
                    _ = userManager.AddToRoleAsync(adminUser, role).Result;
                }
            }
        }
    }
}
