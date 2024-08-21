using EFM.Model.Model;
using EFM.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM.Repository.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
    }
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
