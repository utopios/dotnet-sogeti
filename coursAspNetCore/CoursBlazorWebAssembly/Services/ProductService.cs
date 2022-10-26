using CoursBlazorWebAssembly.Models;

namespace CoursBlazorWebAssembly.Services
{
    public class ProductService
    {
        public List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>() {
            new Product() {Name = "P1", Description= "Produit 1", Price = 100},
            new Product() {Name = "P3", Description= "Produit 3", Price = 300},
            new Product() {Name = "P2", Description= "Produit 2", Price = 200},
            };
        }

        public void Delete(string name)
        {
            Products.RemoveAll(p => p.Name == name);
            //Products = new List<Product>(Products);
        }
    }
}
