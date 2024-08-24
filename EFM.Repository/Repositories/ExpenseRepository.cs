using EFM.Model.Model;
using EFM.Repository.Infrastructure;

namespace EFM.Repository.Repositories
{
    public interface IExpenseRepository : IRepository<Expense>
    {
    }
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
