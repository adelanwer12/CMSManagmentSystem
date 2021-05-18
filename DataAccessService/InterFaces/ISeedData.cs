using System.Threading.Tasks;

namespace DataAccessService.InterFaces
{
    public interface ISeedData
    {
        Task CreateAdminUser();
        Task CreateDefaultUser();
        Task CreateAdminRoles();
        Task CreateCustomerRoles();
    }
}