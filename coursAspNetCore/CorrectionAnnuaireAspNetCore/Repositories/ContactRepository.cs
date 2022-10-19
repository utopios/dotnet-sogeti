using CorrectionAnnuaireAspNetCore.Models;

namespace CorrectionAnnuaireAspNetCore.Repositories
{
    public class ContactRepository : BaseRepository<Contact>
    {
        public override bool Delete(Contact element)
        {
            _dataContext.Contacts.Remove(element);
            return _dataContext.SaveChanges() > 0; 
        }

        public override List<Contact> FindAll()
        {
            return _dataContext.Contacts.ToList();
        }

        public override Contact FindById(int id)
        {
            return _dataContext.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public override bool Save(Contact element)
        {
            _dataContext.Contacts.Add(element);
            return _dataContext.SaveChanges() > 0;
        }

        public List<Contact> FindByPhone(string phone)
        {
            return _dataContext.Contacts.Where(c => c.Phone.Contains(phone)).ToList();
        }
    }
}
