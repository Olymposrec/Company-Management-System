using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Identity
{
    public static class IdentitySeed
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if(await userManager.FindByNameAsync(username) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                var user = new User()
                {
                    UserName = username,
                    Email = email,
                    FirstName = "Admin",
                    LastName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumber = "99999999999"
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
