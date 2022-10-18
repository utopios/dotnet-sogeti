using Microsoft.AspNetCore.Mvc;

namespace ContactAspNet.Controllers
{
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        //Route Ajouter contact
        //[Route("add")]
        [HttpPost("add")]
        public string AddContact()
        {
            return "Ajouter contact";
        }

        //[Route("")]
        [HttpGet("")]
        public string AfficherContacts()
        {
            return "Afficher contacts";
        }

        //[Route("display")]
        [HttpGet("display")]
        public string AfficherContact()
        {
            return "Afficher contact";
        }
        //[Route("delete")]
        [HttpDelete("delete")]
        public string SupprimerContact()
        {
            return "Supprimer Contact";
        }
    }
}
