using CorrectionAnnuaireAspNetCore.Models;
using CorrectionAnnuaireAspNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CorrectionAnnuaireAspNetCore.Controllers
{
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private ContactRepository _contactRepository;
        public ContactController(ContactRepository contactRepository)
        {
            //contactRepository = new ContactRepository();
            _contactRepository = contactRepository;
        }

        [HttpPost("add")]
        public Contact AddContact([FromBody] Contact contact)
        {
            if(_contactRepository.Save(contact))
            {
                return contact;
            }
            return null;
        }

        //[Route("")]
        [HttpGet("")]
        public List<Contact> AfficherContacts()
        {
            return _contactRepository.FindAll();
        }

        [HttpGet("search/{phone}")]
        public List<Contact> RechercherContacts(string phone)
        {
            return _contactRepository.FindByPhone(phone);
        }

        //[Route("display")]
        [HttpGet("display/{id}")]
        public Contact AfficherContact(int id)
        {
            return _contactRepository.FindById(id);
        }
        //[Route("delete")]
        [HttpDelete("delete/{id}")]
        public bool SupprimerContact(int id)
        {
            Contact contact = _contactRepository.FindById(id);
            if(contact != null)
            {
                return _contactRepository.Delete(contact);
            }
            return false;
        }

        [HttpPut("update/{id}")]
        public bool MettreAjour(int id, [FromBody] Contact newcontact)
        {
            Contact contact = _contactRepository.FindById(id);
            if(contact != null)
            {
                contact.FirstName = newcontact.FirstName;
                contact.LastName = newcontact.LastName;
                contact.Phone = newcontact.Phone;
                contact.Email = newcontact.Email;
                return _contactRepository.Update();
            }
            return false;
        }
    }
}
