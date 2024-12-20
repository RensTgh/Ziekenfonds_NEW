using Microsoft.AspNetCore.Identity;
using System.Data.Common;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Services
{
    public class IdentitySeeding
    {
        public async Task IdentitySeedingAsync(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                // Rollen aanmaken
                bool role = await roleManager.RoleExistsAsync("deelnemer");
                if (!role) await roleManager.CreateAsync(new IdentityRole("deelnemer"));

                role = await roleManager.RoleExistsAsync("monitor");
                if (!role) await roleManager.CreateAsync(new IdentityRole("monitor"));

                role = await roleManager.RoleExistsAsync("ouder");
                if (!role) await roleManager.CreateAsync(new IdentityRole("ouder"));

                // Admin
                role = await roleManager.RoleExistsAsync("admin");
                if (!role) await roleManager.CreateAsync(new IdentityRole("admin"));

                // Gebruiker aanmaken
                // Admin bestaat nog niet?
                if (userManager.FindByNameAsync("admin").Result == null)
                {
                    // Gebruiker voorzien
                    var defaultUser = new CustomUser
                    {
                        UserName = "admin",
                        Email = "admin@thomasmore.be",
                        EmailConfirmed = true
                    };

                    // Gebruiker aanmaken
                    var admin = await userManager.CreateAsync(defaultUser, "Welkom@01");
                    if (admin.Succeeded && userManager.FindByNameAsync("admin").Result != null)
                        await userManager.AddToRoleAsync(defaultUser, "admin");
                }
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}