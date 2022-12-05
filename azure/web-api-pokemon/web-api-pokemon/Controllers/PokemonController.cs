using Microsoft.AspNetCore.Authorization;
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
    private UserAppService _userAppService;

    public PokemonController(PokemonService pokemonService, UserAppService userAppService)
    {
        _pokemonService = pokemonService;
        _userAppService = userAppService;

    }

    [Authorize("admin")]
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

    [Authorize("admin")]
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

    [Authorize("user")]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_pokemonService.GetAll());
    }
    [Authorize("user")]
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
    [Authorize("user")]
    [HttpGet("random")]
    public IActionResult RandomPokemon()
    {
        try
        {
            PokemonResponseDTO pokemonResponseDto = _pokemonService.GetRandom();
            _userAppService.AddPokemon(pokemonResponseDto.Id);
            return Ok(pokemonResponseDto);
        }
        catch (Exception e)
        {
            return NotFound(new { Message = e.Message });
        }
    }
}