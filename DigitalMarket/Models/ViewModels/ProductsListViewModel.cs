using DigitalMarket.Models.Entities;

namespace DigitalMarket.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string CurrentCategory { get; set; }

        public string SearchString { get; set; }
    }
}
