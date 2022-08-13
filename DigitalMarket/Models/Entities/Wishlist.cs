namespace DigitalMarket.Models.Entities
{
    public class Wishlist
    {
        private List<WishlistLine> _wishlistCollection = new List<WishlistLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            WishlistLine line = _wishlistCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                _wishlistCollection.Add(new WishlistLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else line.Quantity += quantity;
        }

        public virtual void RemoveLine(Product product) => 
            _wishlistCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);

        public virtual void Clear() => _wishlistCollection.Clear();

        public virtual IEnumerable<WishlistLine> Lines => _wishlistCollection;
    }

    public class WishlistLine
    {
        public int WishlistLineID { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
