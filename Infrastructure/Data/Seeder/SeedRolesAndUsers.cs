using Microsoft.AspNetCore.Identity;
using WebApplication1.Domain.Entities;

public static class SeedRolesAndUsers
{
    public static async Task Initialize(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        var roleNames = new[] { "Admin", "Customer", "Manager" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var defaultUser = await userManager.FindByEmailAsync("admin@example.com");
        if (defaultUser == null)
        {
            var user = new User
            {
                UserName = "admin@example.com",
                Email = "admin@example.com"
            };
            var result = await userManager.CreateAsync(user, "Password123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
