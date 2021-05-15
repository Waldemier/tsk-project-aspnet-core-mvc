namespace TSKApp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using TSKApp.BLL.Interfaces;
    using TSKApp.DAL.Data;
    using TSKApp.DAL.Models;

    public static class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            var roleMng = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await roleMng.CreateAsync(new IdentityRole { Name = "Student", NormalizedName = "STUDENT" });
            await roleMng.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });

            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            var admin = await userManager.CreateAsync(new AppUser() { Email = "admin@gmail.com", FirstName = "admin", LastName = "admin", UserName = "admin@gmail.com" }, "Admin123!" );
            if (admin.Succeeded)
            {
                var adminUser = await userManager.FindByEmailAsync("admin@gmail.com");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
