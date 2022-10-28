using CashRegistryBlazor.Models;

namespace CashRegistryBlazor.Services
{
    public class ProductService
    {
        public List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>() { new Product() { Name ="product 1", Description="descirption", Price=100, Stock=100, Id=1} };
        }

        public bool AddProduct(Product product)
        {
            product.Id = Products[Products.Count - 1].Id + 1;
            Products.Add(product);
            return true;
        }

        public Product? GetProductById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
