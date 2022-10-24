using ApiCashRegistry.Models;
using ApiCashRegistry.Tools;

namespace ApiCashRegistry.Repositories
{
    public class ProductRepository : BaseRespository<Product>
    {
        public ProductRepository(DataDbContext dataContext) : base(dataContext)
        {
        }

        public override List<Product> FindAll()
        {
            return _dataContext.Products.ToList();
        }

        public override Product FindById(int id)
        {
            return _dataContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public override bool Save(Product element)
        {
            _dataContext.Products.Add(element);
            return Update();
        }

        public override List<Product> SearchAll(Func<Product, bool> SearchMethod)
        {
            return _dataContext.Products.Where(SearchMethod).ToList();
        }

        public override Product SearchOne(Func<Product, bool> SearchMethod)
        {
            return _dataContext.Products.FirstOrDefault(SearchMethod);
        }
    }
}
