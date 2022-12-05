using web_api_pokemon.Tools;

namespace web_api_pokemon.Repositories;

public abstract class BaseRepository<T>
{
    protected DataBaseContext _dataBaseContext;

    protected BaseRepository(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    
    public abstract bool Save(T element);
    public abstract T FindById(int id);
    public abstract List<T> FindAll();

    public bool Update()
    {
        return _dataBaseContext.SaveChanges() > 0;
    }
}