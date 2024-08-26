using EFM.Model.Model;
using EFM.Repository.Infrastructure;

namespace EFM.Repository.Repositories
{
    public interface IFamilyRepository : IRepository<Family>
    {
    }
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {
        public FamilyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
