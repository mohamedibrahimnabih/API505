using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Repository.IRepository;

namespace ECommerce.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
