using EFM.Model.Model;
using EFM.Repository.Infrastructure;

namespace EFM.Repository.Repositories
{
    public interface IIncomeRepository : IRepository<Income>
    {
    }
    public class IncomeRepository : RepositoryBase<Income>, IIncomeRepository
    {
        public IncomeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
