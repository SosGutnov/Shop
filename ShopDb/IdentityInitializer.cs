using Microsoft.AspNetCore.Identity;
using ShopDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDb
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@gmail.com";
            var password = "_Aa123456";
            if (roleManager.FindByNameAsync(Constants.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName)).Wait();
            }
            if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName)).Wait();
            }
            var admin = userManager.FindByNameAsync(adminEmail).Result;
            if (admin == null)
            {
                var newAdmin = new User { Email = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(newAdmin, password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(newAdmin, Constants.AdminRoleName).Wait();
                }
            }
            else
            {
                userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
            }
        }
    }
}
