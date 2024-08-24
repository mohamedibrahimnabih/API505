using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Repository.IRepository;

namespace ECommerce.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
