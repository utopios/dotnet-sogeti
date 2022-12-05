using web_api_pokemon.DTOs;
using web_api_pokemon.Models;
using web_api_pokemon.Repositories;
using web_api_pokemon.Services.Interfaces;

namespace web_api_pokemon.Services;

public class PokemonService
{
    private PokemonRepository _pokemonRepository;
    private IUpload _upload;
    public PokemonService(PokemonRepository pokemonRepository, IUpload upload)
    {
        _pokemonRepository = pokemonRepository;
        _upload = upload;
    }

    public PokemonResponseDTO AddPokemon(PokemonRequestDTO pokemonRequestDto)
    {
        Pokemon pokemon = new Pokemon() { Name = pokemonRequestDto.Name };
        if (_pokemonRepository.Save(pokemon))
        {
            return new PokemonResponseDTO() { Id = pokemon.Id, Name = pokemon.Name };
        }

        throw new Exception("Erreur serveur de base de données");
    }

    public List<PokemonResponseDTO> GetAll()
    {
        List<PokemonResponseDTO> responseDtos = new List<PokemonResponseDTO>();
        _pokemonRepository.FindAll().ForEach(p =>
        {
            PokemonResponseDTO response = new PokemonResponseDTO() { Id = p.Id, Name = p.Name };
            p.Images.ForEach(i =>
            {
                response.Images.Add(new ImageDto(){Url = i.Url});
            });
            responseDtos.Add(response);
        });
        return responseDtos;
    }
    
    public PokemonResponseDTO GetById(int id)
    {
        Pokemon pokemon = _pokemonRepository.FindById(id);
        if (pokemon != null)
        {
            PokemonResponseDTO response = new PokemonResponseDTO() { Id = pokemon.Id, Name = pokemon.Name };
            pokemon.Images.ForEach(i =>
            {
                response.Images.Add(new ImageDto(){Url = i.Url});
            });
            return response;
        }

        throw new Exception("Aucun pokemon avec cet id");
    }
    
    public PokemonResponseDTO GetRandom()
    {
        Pokemon pokemon = _pokemonRepository.FindRandom();
        if (pokemon != null)
        {
            PokemonResponseDTO response = new PokemonResponseDTO() { Id = pokemon.Id, Name = pokemon.Name };
            pokemon.Images.ForEach(i =>
            {
                response.Images.Add(new ImageDto(){Url = i.Url});
            });
            return response;
        }

        throw new Exception("Aucun pokemon trouvé");
    }

    public bool AddImage(int id, IFormFile img)
    {
        try
        {
            Pokemon pokemon = _pokemonRepository.FindById(id);
            if (pokemon != null)
            {
                Image image = new Image() { Url = _upload.UploadImage(img) };
                pokemon.Images.Add(image);
                return _pokemonRepository.Update();
            }

            throw new Exception("Aucun pokemon avec l'id");
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}