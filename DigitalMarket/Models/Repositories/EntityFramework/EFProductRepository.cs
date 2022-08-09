using DigitalMarket.Data;
using DigitalMarket.Models.Entities;
using DigitalMarket.Models.Repositories.Abstract;

namespace DigitalMarket.Models.Repositories.EntityFramework
{
    public class EFProductRepository : IProductRepository
    {
        private DigitalMarketDbContext _context;

        public EFProductRepository(DigitalMarketDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}
