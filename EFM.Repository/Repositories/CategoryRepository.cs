using EFM.Model.Model;
using EFM.Repository.Infrastructure;

namespace EFM.Repository.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
