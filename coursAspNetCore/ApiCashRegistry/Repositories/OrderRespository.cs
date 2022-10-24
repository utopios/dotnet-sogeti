using ApiCashRegistry.Models;
using ApiCashRegistry.Tools;
using Microsoft.EntityFrameworkCore;

namespace ApiCashRegistry.Repositories
{
    public class OrderRespository : BaseRespository<Order>
    {
        public OrderRespository(DataDbContext dataContext) : base(dataContext)
        {
        }

        public override List<Order> FindAll()
        {
            return _dataContext.Orders.Include(o => o.Products).ThenInclude(p => p.Product).ToList();
        }

        public override Order FindById(int id)
        {
            return _dataContext.Orders.Include(o => o.Products).ThenInclude(p => p.Product).FirstOrDefault(o => o.Id == id);
        }

        public override bool Save(Order element)
        {
            _dataContext.Orders.Add(element);
            return Update();
        }

        public override List<Order> SearchAll(Func<Order, bool> SearchMethod)
        {
            return _dataContext.Orders.Include(o => o.Products).ThenInclude(p => p.Product).Where(SearchMethod).ToList();
        }

        public override Order SearchOne(Func<Order, bool> SearchMethod)
        {
            return _dataContext.Orders.Include(o => o.Products).ThenInclude(p => p.Product).FirstOrDefault(SearchMethod);
        }
    }
}
