using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCoreMVC.Controllers
{
    public class TotoController : Controller
    {
        public string Index()
        {
            return "Hello from toto";
        }

        public string Titi()
        {
            return "Hello from titi method in toto controller";
        }
    }
}
