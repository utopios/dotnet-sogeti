using CorrectionAnnuaireBlazor.Models;

namespace CorrectionAnnuaireBlazor.Services
{
    public class ContactService
    {
        public List<Contact> Contacts { get; set; }

        public ContactService()
        {
            Contacts = new List<Contact>()
            {
                new Contact()
                {
                   Id = 1, 
                   FirstName = "toto", 
                   LastName = "tata",
                   Phone = "010101010101",
                   Emails = new List<Email>() {
                       new Email() { Id = 1, Mail = "toto@tata.fr"},
                       new Email() { Id = 2, Mail = "tata@toto.fr"},
                   }
                },
                new Contact()
                {
                   Id = 2,
                   FirstName = "titi",
                   LastName = "minet",
                   Phone = "0202020202",
                   Emails = new List<Email>() {
                       new Email() { Id = 1, Mail = "titi@minet.fr"},
                       new Email() { Id = 2, Mail = "minet@titi.fr"},
                   }
                }
            };
        }

        public bool DeleteContact(int id)
        {
            return Contacts.RemoveAll(c => c.Id == id) > 0;
        }

        public bool DeleteEmail(int id, int emailId)
        {
            Contact? contact = Contacts.FirstOrDefault(c => c.Id == id);
            if(contact != null)
            {
                return contact.Emails.RemoveAll(e => e.Id == emailId) > 0;
            }
            return false;
        }

        public Contact? FindById(int id)
        {
            return Contacts.FirstOrDefault(c => c.Id == id);
        }

        public bool AddContact(Contact contact)
        {
            contact.Id = Contacts[Contacts.Count - 1].Id + 1;
            Contacts.Add(contact);
            return true;
        }
    }
}
