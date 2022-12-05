using Microsoft.EntityFrameworkCore;
using web_api_pokemon.Models;
using web_api_pokemon.Tools;

namespace web_api_pokemon.Repositories;

public class PokemonRepository : BaseRepository<Pokemon>
{
    public PokemonRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override bool Save(Pokemon? element)
    {
        _dataBaseContext.Pokemons.Add(element);
        return Update();
    }

    public override Pokemon? FindById(int id)
    {
        return _dataBaseContext.Pokemons.Include(p => p.Images).FirstOrDefault(p => p != null && p.Id == id);
    }
    
    public Pokemon? FindRandom()
    {
        return _dataBaseContext.Pokemons.Include(p => p.Images).OrderBy(r => Guid.NewGuid()).Take(1).First();
    }

    public override List<Pokemon> FindAll()
    {
        return _dataBaseContext.Pokemons.Include(p => p.Images).ToList();
    }
}