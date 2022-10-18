using Microsoft.AspNetCore.Mvc;

namespace coursAspNetCore.Controllers
{
    
    [Route("[controller]")]
    public class TotoController : ControllerBase
    {
        //[Route("")]
        [HttpGet("")]
        public string Index()
        {
            return "Index";
        }

        //[Route("titi")]
        [HttpPost("titi")]
        public string Titi()
        {
            return "hello from index";
        }
    }
}
