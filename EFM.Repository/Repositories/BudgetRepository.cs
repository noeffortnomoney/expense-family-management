using EFM.Model.Model;
using EFM.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
