using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using web_api_pokemon.Models;
using web_api_pokemon.Repositories;
using web_api_pokemon.Services.Interfaces;

namespace web_api_pokemon.Services;

public class LoginJwtService : ILogin
{
    private UserAppRepository _repository;

    public LoginJwtService(UserAppRepository repository)
    {
        _repository = repository;
    }
    public string Login(string name, string password)
    {
        UserApp user = _repository.SearchOne(u => u.Name == name && u.Password == password);
        if (user != null)
        {
            //Créer le token 
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour je suis la clé de sécurité pour générer la JWT")), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Issuer = "sogeti",
                Audience = "sogeti"

            };
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
        return null;
    }
}