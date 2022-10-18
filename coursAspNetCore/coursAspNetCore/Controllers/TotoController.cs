using Microsoft.AspNetCore.Mvc;

namespace coursAspNetCore.Controllers
{
    
    [Route("[controller]")]
    public class TotoController : ControllerBase
    {
        [Route("")]
        public string Index()
        {
            return "Index";
        }

        [Route("titi")]
        public string Titi()
        {
            return "hello from index";
        }
    }
}
