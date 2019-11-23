using GACKO.DB.DaoModels;
using GACKO.Shared.Models.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO
{
    public class DbInitializer
    {
        private const string AdminRoleName = "Administrator";

        private List<UserRegisterForm> Users = new List<UserRegisterForm>()
        {
            new UserRegisterForm(){ FirstName = "admin", LastName = "Administrator", UserName= "Administrator", Password = "Admin123$" }
        };

        public async Task Initialize(
            UserManager<DaoUser> userManager,
            RoleManager<DaoRole> roleManager)
        {
            await FirstConfigUserRoles(userManager, roleManager);
        }

        private async Task CreateRole(string roleName, RoleManager<DaoRole> roleManager)
        {
            if (!(await roleManager.RoleExistsAsync(roleName)))
            {
                await roleManager.CreateAsync(new DaoRole { Name = roleName });
            }
        }

        private async Task FirstConfigUserRoles(UserManager<DaoUser> userManager, RoleManager<DaoRole> roleManager)
        {
            await CreateRole(AdminRoleName, roleManager);

            int id = 100;
            foreach (var item in Users)
            {
                try
                {
                    var userExists = await userManager.FindByNameAsync(item.UserName);

                    if (userExists == null)
                    {
                        var user = new DaoUser
                        {
                            Id = id++,
                            Email = $"{item.UserName}@gacko.pl",
                            UserName = item.UserName,
                            EmailConfirmed = true,
                            FirstName = item.FirstName,
                            LastName = item.LastName
                        };

                        await userManager.CreateAsync(user, item.Password);
                        await userManager.AddToRoleAsync(user, AdminRoleName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
