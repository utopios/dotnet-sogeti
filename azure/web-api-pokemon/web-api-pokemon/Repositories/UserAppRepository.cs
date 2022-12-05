using Microsoft.EntityFrameworkCore;
using web_api_pokemon.Models;
using web_api_pokemon.Tools;

namespace web_api_pokemon.Repositories;

public class UserAppRepository : BaseRepository<UserApp>
{
    public UserAppRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
    }

    public override bool Save(UserApp element)
    {
        throw new NotImplementedException();
    }

    public override UserApp FindById(int id)
    {
        throw new NotImplementedException();
    }

    public override List<UserApp> FindAll()
    {
        throw new NotImplementedException();
    }

    public UserApp SearchOne(Func<UserApp, bool> searchMethode)
    {
        return _dataBaseContext.Users.Include(u => u.Role).Where(searchMethode).First();
    }
}