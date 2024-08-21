using EFM.Model.Model;
using EFM.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
