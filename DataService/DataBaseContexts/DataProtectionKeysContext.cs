using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataService.DataBaseContexts
{
    public class DataProtectionKeysContext : DbContext, IDataProtectionKeyContext
    {
        public DataProtectionKeysContext(DbContextOptions<DataProtectionKeysContext> options) : base(options)
        {
        }

        public DbSet<DataProtectionKey> DataProtectionKeys {get;set;}
    }
}