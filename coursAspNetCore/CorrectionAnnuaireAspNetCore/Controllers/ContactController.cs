using CorrectionAnnuaireAspNetCore.Models;
using CorrectionAnnuaireAspNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CorrectionAnnuaireAspNetCore.Controllers
{
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private ContactRepository contactRepository;
        public ContactController()
        {
            contactRepository = new ContactRepository();
        }

        [HttpPost("add")]
        public Contact AddContact([FromBody] Contact contact)
        {
            if(contactRepository.Save(contact))
            {
                return contact;
            }
            return null;
        }

        //[Route("")]
        [HttpGet("")]
        public List<Contact> AfficherContacts()
        {
            return contactRepository.FindAll();
        }

        [HttpGet("search/{phone}")]
        public List<Contact> RechercherContacts(string phone)
        {
            return contactRepository.FindByPhone(phone);
        }

        //[Route("display")]
        [HttpGet("display/{id}")]
        public Contact AfficherContact(int id)
        {
            return contactRepository.FindById(id);
        }
        //[Route("delete")]
        [HttpDelete("delete/{id}")]
        public bool SupprimerContact(int id)
        {
            Contact contact = contactRepository.FindById(id);
            if(contact != null)
            {
                return contactRepository.Delete(contact);
            }
            return false;
        }

        [HttpPut("update/{id}")]
        public bool MettreAjour(int id, [FromBody] Contact newcontact)
        {
            Contact contact = contactRepository.FindById(id);
            if(contact != null)
            {
                contact.FirstName = newcontact.FirstName;
                contact.LastName = newcontact.LastName;
                contact.Phone = newcontact.Phone;
                contact.Email = newcontact.Email;
                return contactRepository.Update();
            }
            return false;
        }
    }
}
