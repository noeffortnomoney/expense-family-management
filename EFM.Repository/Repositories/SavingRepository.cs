using EFM.Model.Model;
using EFM.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
