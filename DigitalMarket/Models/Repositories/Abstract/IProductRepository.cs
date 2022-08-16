using DigitalMarket.Models.Entities;

namespace DigitalMarket.Models.Repositories.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        Product GetProductById(int id);
    }
}
