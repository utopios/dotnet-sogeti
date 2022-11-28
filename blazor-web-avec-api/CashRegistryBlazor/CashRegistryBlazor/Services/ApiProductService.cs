using System.Net.Http.Json;
using CashRegistryBlazor.Interfaces;
using CashRegistryBlazor.Models;

namespace CashRegistryBlazor.Services;

public class ApiProductService : IProductService
{
    private HttpClient _httpClient;

    public ApiProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<Product>?> GetProductsAsync(string search = null)
    {
        return (List<Product>?)await _httpClient.GetFromJsonAsync("/product", typeof(List<Product>));
    }

    public List<Product> GetProducts(string search = null)
    {
        throw new NotImplementedException();
    }

    public Product? GetProductById(int id)
    {
        throw new NotImplementedException();
    }
}