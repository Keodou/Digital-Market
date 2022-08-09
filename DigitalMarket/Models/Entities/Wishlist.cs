namespace DigitalMarket.Models.Entities
{
    public class Wishlist
    {
        private List<WishlistLine> wishlistCollection = new List<WishlistLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            WishlistLine line = wishlistCollection
                .Where(p => p.Product.ProductName == product.ProductName)
                .FirstOrDefault();
        }
    }

    public class WishlistLine
    {
        public int WishlistLineID { get; set; }

        public Product Product { get; set; }
    }
}
