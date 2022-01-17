using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FictionalCustomer.WebApp.Data
{
    public class SeedRoles
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
                context.Database.Migrate();
                CreateRoles(userManager, roleManager, configuration);
            }
        }

        private static void CreateRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var adminRoleName = "Admin";
            var userRoleName = "User";
            var adminUserName = configuration?["AdminInfo:ADMINUSER"];
            var adminPassword = configuration?["AdminInfo:ADMINPASSWORD"];
            if (string.IsNullOrWhiteSpace(adminUserName) || string.IsNullOrWhiteSpace(adminPassword))
            {
                throw new ArgumentNullException(adminUserName, adminPassword);
            }

            bool foundRole = roleManager.RoleExistsAsync(adminRoleName).Result;

            if (!foundRole)
            {
                roleManager.CreateAsync(new IdentityRole(adminRoleName)).GetAwaiter().GetResult();
            }

            foundRole = roleManager.RoleExistsAsync(userRoleName).Result;

            if (!foundRole)
            {
                roleManager.CreateAsync(new IdentityRole(userRoleName)).GetAwaiter().GetResult();
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
                    _ = userManager.AddToRoleAsync(adminUser, adminRoleName).Result;
                }
            }
        }
    }
}
