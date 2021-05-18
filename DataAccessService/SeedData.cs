using System;
using System.Threading.Tasks;
using CommonService;
using DataAccessService.InterFaces;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace DataAccessService
{
    public class SeedData: ISeedData
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedData( UserManager<IdentityUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateAdminUser()
        {
            try
            {
                var adminUser = new IdentityUser
                {
                    Email = "admin@admin.com",
                    UserName = "admin",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456",
                    PhoneNumberConfirmed = true,
                };

                var result = await _userManager.CreateAsync(adminUser, "Admin123@");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, StringsConst.AdminRole);
                    Log.Information("Admin User Created {UserName}", adminUser.UserName);
                }
                else
                {
                    var errorSting = string.Join(",", result.Errors);
                    Log.Error("Error while Creating Admin User {Error}", errorSting);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error While Creating Admin User {Error} {StackTrace} {InnerException} {Source}", e.Message,
                    e.StackTrace, e.InnerException, e.Source);
            }
        }
        

        public async Task CreateDefaultUser()
        {
            try
            {
                var appUser = new IdentityUser
                {
                    Email = "regular@admin.com",
                    UserName = "regular",
                    EmailConfirmed = true,
                    PhoneNumber = "01234567",
                    PhoneNumberConfirmed = true,
                };

                var result = await _userManager.CreateAsync(appUser, "AppUser123@");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, StringsConst.CustomerRole);
                    Log.Information("User Created {UserName}", appUser.UserName);
                }
                else
                {
                    var errorSting = string.Join(",", result.Errors);
                    Log.Error("Error while Creating User {Error}", errorSting);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error While Creating User {Error} {StackTrace} {InnerException} {Source}", e.Message,
                    e.StackTrace, e.InnerException, e.Source);
            }
        }

        
       public async Task CreateAdminRoles()
        {
            try
            {
                var adminRole = new IdentityRole
                    {Name = "Administrator", NormalizedName = "ADMINISTRATOR"};

                var result = await _roleManager.CreateAsync(adminRole);
                if (result.Succeeded)
                {
                    Log.Information("User Created {UserName}", adminRole.Name);
                }
                else
                {
                    var errorSting = string.Join(",", result.Errors);
                    Log.Error("Error while Creating User {Error}", errorSting);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error While Creating Roles {Error} {StackTrace} {InnerException} {Source}", e.Message,
                    e.StackTrace, e.InnerException, e.Source);
            }
        }
       
       public async Task CreateCustomerRoles()
       {
           try
           {
               var customerRole = new IdentityRole
                   {Id = Guid.NewGuid().ToString(), Name = "Customer", NormalizedName = "CUSTOMER"};

               var result = await _roleManager.CreateAsync(customerRole);
               if (result.Succeeded)
               {
                   Log.Information("User Created {UserName}", customerRole.Name);
               }
               else
               {
                   var errorSting = string.Join(",", result.Errors);
                   Log.Error("Error while Creating User {Error}", errorSting);
               }
           }
           catch (Exception e)
           {
               Log.Error("Error While Creating Roles {Error} {StackTrace} {InnerException} {Source}", e.Message,
                   e.StackTrace, e.InnerException, e.Source);
           }
       }

        private string GetDefaultProfilePic()
        {
            return string.Empty;
        }
    }
}