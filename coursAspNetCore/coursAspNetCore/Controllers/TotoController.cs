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

        [HttpPost("form_data")]
        //FromForm => form-data ou x-www-form-urlencoded
        public string ActionFormData([FromForm]string arg1, [FromForm] string arg2)
        {
            return arg1 + arg2;
        }


        [HttpPost("form_body")]
        //FromBody => body json, text, 
        public string ActionFormBody([FromBody] WeatherForecast weather)
        {
            return weather.ToString();
        }

        [HttpGet("weather")]
        public WeatherForecast TotoWeather()
        {
            return new WeatherForecast()
            {
                TemperatureC = 19
            };
        }

        [HttpGet("weathers")]
        public List<WeatherForecast> TotoWeathers()
        {
            return new List<WeatherForecast>()
            {
                new WeatherForecast() { TemperatureC = 19},
                new WeatherForecast() { TemperatureC = 18},
                new WeatherForecast() { TemperatureC = 17},
            };
        }
    }
}
