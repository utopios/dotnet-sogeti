using System.Security.Claims;
using web_api_pokemon.Models;
using web_api_pokemon.Repositories;

namespace web_api_pokemon.Services;

public class UserAppService
{
    private UserAppRepository _userAppRepository;
    private PokemonRepository _pokemonRepository;
    private IHttpContextAccessor _httpContextAccessor;
    public UserAppService(UserAppRepository userAppRepository, PokemonRepository pokemonRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userAppRepository = userAppRepository;
        _pokemonRepository = pokemonRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public bool AddPokemon(int id)
    {
        string name = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        UserApp user = _userAppRepository.SearchOne(u => u.Name == name);
        if (user != null)
        {
            user.Pokemons.Add(new PokemonUser() {User = user, Pokemon = _pokemonRepository.FindById(id)});
            return _userAppRepository.Update();
        }

        return false;
    }
    
}