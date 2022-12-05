using web_api_pokemon.Models;

namespace web_api_pokemon.DTOs;

public class PokemonResponseDTO
{
    public  int Id { get; set; }
    public string Name { get; set; }
    
    public List<ImageDto> Images { get; set; }

    public PokemonResponseDTO()
    {
        Images = new List<ImageDto>();
    }
}