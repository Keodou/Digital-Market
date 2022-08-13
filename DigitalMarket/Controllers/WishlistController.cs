using DigitalMarket.Extensions;
using DigitalMarket.Models.Entities;
using DigitalMarket.Models.Repositories.Abstract;
using DigitalMarket.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IProductRepository _repository;

        public WishlistController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new WishlistViewModel
            {
                Wishlist = GetWishlist(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToWishlist(int productId, string returnUrl)
        {
            var product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                var wishlist = GetWishlist();
                wishlist.AddItem(product, 1);
                SaveWishlist(wishlist);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromWishlist(int productId, string returnUrl)
        {
            var product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                var wishlist = GetWishlist();
                wishlist.RemoveLine(product);
                SaveWishlist(wishlist);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Wishlist GetWishlist()
        {
            Wishlist wishlist = HttpContext.Session.GetJson<Wishlist>("Wishlist") ?? new Wishlist();
            return wishlist;
        }

        private void SaveWishlist(Wishlist wishlist)
        {
            HttpContext.Session.SetJson("Wishlist", wishlist);
        }
    }
}
