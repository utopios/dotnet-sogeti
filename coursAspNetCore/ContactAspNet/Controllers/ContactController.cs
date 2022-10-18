using Microsoft.AspNetCore.Mvc;

namespace ContactAspNet.Controllers
{
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        //Route Ajouter contact
        [Route("add")]
        public string AddContact()
        {
            return "Ajouter contact";
        }

        [Route("")]
        public string AfficherContacts()
        {
            return "Afficher contacts";
        }

        [Route("display")]
        public string AfficherContact()
        {
            return "Afficher contacts";
        }
        [Route("delete")]
        public string SupprimerContact()
        {
            return "Supprimer Contact";
        }
    }
}
