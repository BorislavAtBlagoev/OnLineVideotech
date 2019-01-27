using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using System.Threading.Tasks;

namespace OnLineVideotech.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<OnLineVideotechDbContext>().Database.Migrate();

                UserManager<User> userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    string adminName = GlobalConstants.AdministratorRole;

                    bool roleExists = await roleManager.RoleExistsAsync(adminName);

                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminName,
                        });
                    }

                    User adminUser = await userManager.FindByNameAsync(adminName);
                    string adminEmail = "admin@mysite.com";

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = adminEmail,
                            UserName = adminEmail
                        };

                        await userManager.CreateAsync(adminUser, "admin");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}