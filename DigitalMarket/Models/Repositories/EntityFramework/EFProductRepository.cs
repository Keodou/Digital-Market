using DigitalMarket.Data;
using DigitalMarket.Models.Entities;
using DigitalMarket.Models.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

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

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }
    }
}
