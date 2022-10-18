using Microsoft.AspNetCore.Mvc;

namespace ContactAspNet.Controllers
{
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        //Route Ajouter contact
        //[Route("add")]
        [HttpPost("add")]
        public string AddContact([FromBody] Contact contact)
        {
            return "Ajout contact "+contact;
        }

        //[Route("")]
        [HttpGet("")]
        public string AfficherContacts()
        {
            return "Afficher contacts";
        }

        //[Route("display")]
        [HttpGet("display/{id}")]
        public string AfficherContact(int id)
        {
            return "Afficher contact "+id;
        }
        //[Route("delete")]
        [HttpDelete("delete/{id}")]
        public string SupprimerContact(int id)
        {
            return "Supprimer Contact "+id;
        }
    }
}
