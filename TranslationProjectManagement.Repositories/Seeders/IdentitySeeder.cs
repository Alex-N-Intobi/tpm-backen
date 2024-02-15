using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TranslationProjectManagement.Domains;

namespace TranslationProjectManagement.Repositories.Seeders;

public static class IdentitySeeder
{
    public async static void Seed(this IServiceProvider serviceProvider)
    {
        using IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
        ApplicationDbContext context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        List<string> roles = ["Admin", "Translator", "Manager"];

        RoleManager<Role> _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();
        foreach (string role in roles)
        {
            if (!context.Roles.Any(r => r.Name == role))
            {
                await _roleManager.CreateAsync(new Role() { Name = role, NormalizedName = role.ToUpper()});
            }
        }


        User adminUser = new()
        {
            FullName = "Admin",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            UserName = "admin@example.com",
            NormalizedUserName = "ADMIN@EXAMPLE.COM",
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        UserManager<User> _userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
        if (!context.Users.Any(u => u.UserName == adminUser.UserName))
        {
            await _userManager.CreateAsync(adminUser, "password");
            await _userManager.AddToRoleAsync(adminUser, "Admin");
        }

        User managerUser = new()
        {
            FullName = "Manager",
            Email = "manager@example.com",
            NormalizedEmail = "MANAGER@EXAMPLE.COM",
            UserName = "manager@example.com",
            NormalizedUserName = "MANAGER@EXAMPLE.COM",
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        if (!context.Users.Any(u => u.UserName == managerUser.UserName))
        {
            await _userManager.CreateAsync(managerUser, "password");
            await _userManager.AddToRoleAsync(managerUser, "Manager");
        }

        User translatorUser = new()
        {
            FullName = "Translator",
            Email = "translator@example.com",
            NormalizedEmail = "TRANSLATOR@EXAMPLE.COM",
            UserName = "translator@example.com",
            NormalizedUserName = "TRANSLATOR@EXAMPLE.COM",
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        if (!context.Users.Any(u => u.UserName == translatorUser.UserName))
        {
            await _userManager.CreateAsync(translatorUser, "password");
            await _userManager.AddToRoleAsync(translatorUser, "Translator");
        }
    }
}
