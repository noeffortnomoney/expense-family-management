using EFM.Model;
using EFM.Model.Model;
using EFM.Repository.Infrastructure;

namespace EFM.Repository.Repositories
{
        public interface IApplicationUserRepository : IRepository<ApplicationUser>
        {
        }           
        public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
        {
            public ApplicationUserRepository(IDbFactory dbFactory) : base(dbFactory)
            {
            }
        }
}