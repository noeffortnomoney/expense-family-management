using EFM.Model.Model;
using EFM.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
