using DigitalMarket.Models.Repositories.Abstract;
using DigitalMarket.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List(string category, string searchString)
        {
            ViewBag.CurrentFilter = searchString;
            ProductsListViewModel model;

            if (string.IsNullOrEmpty(searchString))
            {
                model = new ProductsListViewModel
                {
                    Products = _repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductName),
                    CurrentCategory = category
                };
            }
            else
            {
                model = new ProductsListViewModel
                {
                    Products = _repository.Products.Where(s => s.ProductName!.Contains(searchString)),
                    SearchString = searchString
                };
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            //if (id == null) 
            //    return NotFound();

            var product = await _repository.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
