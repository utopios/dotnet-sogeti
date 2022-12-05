using Microsoft.AspNetCore.Mvc;
using web_api_pokemon.Services;

namespace web_api_pokemon.Controllers;

public class PokemonController : ControllerBase
{
    private PokemonService _pokemonService;

    public PokemonController(PokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }
}