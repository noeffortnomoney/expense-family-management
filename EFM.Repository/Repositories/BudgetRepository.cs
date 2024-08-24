using EFM.Model.Model;
using EFM.Repository.Infrastructure;

namespace EFM.Repository.Repositories
{
    public interface IBudgetRepository : IRepository<Budget>
    {
    }
    public class BudgetRepository : RepositoryBase<Budget>, IBudgetRepository
    {
        public BudgetRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
