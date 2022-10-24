using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCashRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        //Ajouter une commande => DTO List OrderPorductRequest (id_produit, qty)
        //Réponse Order => (total, List OrderProductResponse (Name, qty, price, total)
    }
}
