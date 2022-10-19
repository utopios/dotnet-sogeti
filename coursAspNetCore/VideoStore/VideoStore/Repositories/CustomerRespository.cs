using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using VideoStore.Tools;

namespace VideoStore.Repositories
{
    public class CustomerRespository : BaseRepository<Customer>
    {
        public CustomerRespository(DataDbContext dataDbContext) : base(dataDbContext)
        {
        }

        public override bool Delete(Customer element)
        {
            _dataDbContext.Customers.Remove(element);
            return _dataDbContext.SaveChanges() > 0;
        }

        public override List<Customer> FindAll()
        {
            return _dataDbContext.Customers.Include(c => c.Loans).ThenInclude(l => l.Movies).ToList();
        }

        public override Customer FindById(int id)
        {
            return _dataDbContext.Customers.Include(c => c.Loans).ThenInclude(l => l.Movies).FirstOrDefault(c => c.Id == id);
        }

        public override bool Save(Customer element)
        {
            _dataDbContext.Customers.Add(element);

            return _dataDbContext.SaveChanges() > 0;
        }

        public override List<Customer> Search(Func<Customer, bool> searchMethod)
        {
            return _dataDbContext.Customers.Where(searchMethod).ToList();
        }
    }
}
