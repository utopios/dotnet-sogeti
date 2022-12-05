namespace web_api_pokemon.Repositories.Interfaces;

public interface IRepository<T>
{
    public bool Save(T element);
    public T FindById(int id);
    public List<T> FindAllById();
}