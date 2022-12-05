using Microsoft.AspNetCore.Mvc;
using web_api_pokemon.DTOs;
using web_api_pokemon.Services;
using web_api_pokemon.Services.Interfaces;

namespace web_api_pokemon.Controllers;

[ApiController]
[Route("pokemon")]
public class PokemonController : ControllerBase
{
    private PokemonService _pokemonService;


    public PokemonController(PokemonService pokemonService)
    {
        _pokemonService = pokemonService;
       
    }

    [HttpPost]
    public IActionResult Post([FromBody] PokemonRequestDTO pokemonRequestDto)
    {
        try
        {
            PokemonResponseDTO response = _pokemonService.AddPokemon(pokemonRequestDto);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erreur serveur" });
        }
    }

    [HttpPut("{id}/image")]
    public IActionResult Put(int id, IFormFile image)
    {
        try
        {
            return Ok(_pokemonService.AddImage(id, image));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_pokemonService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            return Ok(_pokemonService.GetById(id));
        }
        catch (Exception e)
        {
            return NotFound(new { Message = e.Message });
        }
    }

    [HttpGet("random")]
    public IActionResult RandomPokemon()
    {
        try
        {
            return Ok(_pokemonService.GetRandom());
        }
        catch (Exception e)
        {
            return NotFound(new { Message = e.Message });
        }
    }
}