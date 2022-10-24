using ApiCashRegistry.Models;
using ApiCashRegistry.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCashRegistry.Services
{
    public class JWTService
    {
        private UserRespository _userRepository;

        public JWTService(UserRespository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GetJWT(string email, string password)
        {
            CashRegistryUser user = _userRepository.SearchOne(u => u.Email == email && u.Password == password);
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
                        new Claim(ClaimTypes.Role, "client"),
                        new Claim(ClaimTypes.Email, user.Email)
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
}
