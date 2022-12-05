using web_api_pokemon.Repositories;

namespace web_api_pokemon.Services;

public class PokemonService
{
    private PokemonRepository _pokemonRepository;
    public PokemonService(PokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }
}