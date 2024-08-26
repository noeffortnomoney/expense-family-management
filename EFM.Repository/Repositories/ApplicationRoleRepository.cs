using EFM.Model;
using EFM.Model.Model;
using EFM.Repository.Infrastructure;

namespace EFM.Repository.Repositories
{
    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {
    }
    public class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}