using EFM.Model.Model;
using EFM.Repository.Infrastructure;

namespace EFM.Repository.Repositories
{
    public interface ISavingRepository : IRepository<Saving>
    {
    }
    public class SavingRepository : RepositoryBase<Saving>, ISavingRepository
    {
        public SavingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
