using ApiCashRegistry.Models;
using ApiCashRegistry.Tools;

namespace ApiCashRegistry.Repositories
{
    public class UserRespository : BaseRespository<CashRegistryUser>
    {
        public UserRespository(DataDbContext dataContext) : base(dataContext)
        {
        }

        public override List<CashRegistryUser> FindAll()
        {
            throw new NotImplementedException();
        }

        public override CashRegistryUser FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(CashRegistryUser element)
        {
           _dataContext.Users.Add(element);
            return Update();
        }

        public override List<CashRegistryUser> SearchAll(Func<CashRegistryUser, bool> SearchMethod)
        {
            throw new NotImplementedException();
        }

        public override CashRegistryUser SearchOne(Func<CashRegistryUser, bool> SearchMethod)
        {
            return _dataContext.Users.FirstOrDefault(SearchMethod);
        }
    }
}
