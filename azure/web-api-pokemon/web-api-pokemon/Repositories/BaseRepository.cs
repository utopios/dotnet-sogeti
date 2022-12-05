using web_api_pokemon.Tools;

namespace web_api_pokemon.Repositories;

public abstract class BaseRepository<T>
{
    private DataBaseContext _dataBaseContext;

    protected BaseRepository(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    
    public abstract bool Save(T element);
    public abstract T FindById(int id);
    public abstract List<T> FindAllById();

    public bool Update()
    {
        return _dataBaseContext.SaveChanges() > 0;
    }
}