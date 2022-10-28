namespace CashRegistryBlazor.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public List<CartProduct> Products { get; set; }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                Products.ForEach(p =>
                {
                    total += p.Qty * p.Product.Price;
                });
                return total;
            }
        }

        public Cart()
        {
            Products = new();
        }
    }
}
