using ApiCashRegistry.DTOs;
using ApiCashRegistry.Models;
using ApiCashRegistry.Repositories;
using ApiCashRegistry.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCashRegistry.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRespository _userRespository;
        private JWTService _jwtService;

        public UserController(UserRespository userRespository, JWTService jwtService)
        {
            _userRespository = userRespository;
            _jwtService = jwtService;
        }


        //Ajouter un utilisateur DTO (email, password)

        //Réponse DTO (id, email)

        [HttpPost]
        public IActionResult Post([FromBody] UserRequestDTO userRequestDTO)
        {
            CashRegistryUser user = new CashRegistryUser() { Email = userRequestDTO.Email, Password = userRequestDTO.Password };
            if(_userRespository.Save(user))
            {
                return Ok(new UserResponseDTO() { Id = user.Id, Email = user.Email });
            }
            return StatusCode(500);
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] string email, [FromForm] string password)
        {
            string token = _jwtService.GetJWT(email, password);
            if(token != null)
            {
                return Ok(token);
            }
            return StatusCode(402);
        }
    }
}
