using System;
using System.Linq;
using System.Threading.Tasks;
using CommonService;
using DataAccessService.InterFaces;
using DataService.DataBaseContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DataService
{
    public static class DbContextInitializer
    {
        public static async Task DataBaseInitialize(ISeedData seedData)
        {
            await seedData.CreateAdminRoles();
            await seedData.CreateCustomerRoles();
            await seedData.CreateAdminUser();
            await seedData.CreateDefaultUser();
        }
    }
}