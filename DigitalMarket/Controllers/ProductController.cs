using DigitalMarket.Models.Repositories.Abstract;
using DigitalMarket.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List(string category)
        {
            var model = new ProductsListViewModel
            {
                Products = _repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductName),
                CurrentCategory = category
            };

            return View(model);
        }
    }
}
