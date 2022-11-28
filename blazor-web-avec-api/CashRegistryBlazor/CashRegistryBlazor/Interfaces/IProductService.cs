using CashRegistryBlazor.Models;

namespace CashRegistryBlazor.Interfaces;

public interface IProductService
{
    public Task<List<Product>?> GetProductsAsync(string search=null); 
    public List<Product> GetProducts(string search=null);

    public Product? GetProductById(int id);
}