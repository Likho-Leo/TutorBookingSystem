using Microsoft.AspNetCore.Identity;
using TutorBookingSystem.Data;
using TutorBookingSystem.Models;

namespace TutorBookingSystem.Services
{
    public class SeedServices
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedServices>>();

            try
            {
                //Ensure db is ready
                logger.LogInformation("Ensuring the database is created.");
                await context.Database.EnsureCreatedAsync(); //checks if db and tbls are created or not. if not it'll create them usin EF

                //Add roles
                logger.LogInformation("Seeding roles.");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "Tutor");
                await AddRoleAsync(roleManager, "Student");

                //Add Admin User
                logger.LogInformation("Seeding admin user.");
                var adminEmail = "admin1@example.com";
                if(await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new User
                    {
                        FirstName = "Jhon",
                        LastName = "Doe",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(adminUser, "JhonDoe123!");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Admin role to the admin user.");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogInformation("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, "An error occured while seeding the database");
            }
        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
