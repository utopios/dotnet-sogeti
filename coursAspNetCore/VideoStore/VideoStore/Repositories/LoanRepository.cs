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
    public class LoanRepository : BaseRepository<Loan>
    {
        public LoanRepository(DataDbContext dataDbContext) : base(dataDbContext)
        {
        }

        public override bool Delete(Loan element)
        {
            _dataDbContext.Loans.Remove(element);
            return _dataDbContext.SaveChanges() > 0;
        }

        public override List<Loan> FindAll()
        {
            return _dataDbContext.Loans.Include(l => l.Movies).Include(c=>c.Customer).ToList();
        }

        public List<Loan> FindAllByCustomer(Customer customer)
        {
            return _dataDbContext.Loans.Include(l => l.Movies).Include(c => c.Customer).Where(l=>l.Customer == customer).ToList();
        }

        public override Loan FindById(int id)
        {
            return _dataDbContext.Loans.Include(l => l.Movies).Include(c => c.Customer).FirstOrDefault(l => l.Id == id);
        }

        public override bool Save(Loan element)
        {
            _dataDbContext.Loans.Add(element);
            return _dataDbContext.SaveChanges() > 0;
        }

        public override List<Loan> Search(Func<Loan, bool> searchMethod)
        {
            throw new NotImplementedException();
        }
    }
}
