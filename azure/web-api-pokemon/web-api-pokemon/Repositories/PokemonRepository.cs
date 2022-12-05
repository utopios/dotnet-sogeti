using web_api_pokemon.Models;
using web_api_pokemon.Tools;

namespace web_api_pokemon.Repositories;

public class PokemonRepository : BaseRepository<Pokemon>
{
    public PokemonRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override bool Save(Pokemon element)
    {
        throw new NotImplementedException();
    }

    public override Pokemon FindById(int id)
    {
        throw new NotImplementedException();
    }

    public override List<Pokemon> FindAllById()
    {
        throw new NotImplementedException();
    }
}