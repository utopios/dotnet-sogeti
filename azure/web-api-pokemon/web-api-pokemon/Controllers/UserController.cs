using Microsoft.AspNetCore.Mvc;
using web_api_pokemon.Services.Interfaces;

namespace web_api_pokemon.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
   
    private ILogin _login;

    public UserController(ILogin login)
    {
        _login = login;
    }

    
    [HttpPost("login")]
    public IActionResult Login([FromForm] string name, [FromForm] string password)
    {
        string token = _login.Login(name, password);
        if(token != null)
        {
            return Ok(token);
        }
        return StatusCode(402);
    }
}