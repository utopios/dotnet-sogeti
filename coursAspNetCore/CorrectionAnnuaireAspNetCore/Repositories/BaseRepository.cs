using CorrectionAnnuaireAspNetCore.Tools;

namespace CorrectionAnnuaireAspNetCore.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected DataDbContext _dataContext { get; set; }

        public BaseRepository(DataDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public abstract bool Save(T element);

        public abstract List<T> FindAll();

        public abstract T FindById(int id);

        public abstract bool Delete(T element);

        public virtual bool Update()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
