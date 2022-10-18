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

        [HttpGet("url_data/{arg1}/{arg2}")]
        public string ActionWithArg(int arg1, int arg2)
        {
            return (arg1 + arg2).ToString();
        }
    }
}
