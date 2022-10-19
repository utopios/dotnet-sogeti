using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using VideoStore.Tools;

namespace VideoStore.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected DataDbContext _dataDbContext;

        public BaseRepository(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

       
        public abstract bool Save(T element);

        public abstract T FindById(int id);

        public virtual bool Update()
        {
            return _dataDbContext.SaveChanges() > 0;
        }

        public abstract List<T> Search(Func<T, bool> searchMethod);

        public abstract bool Delete(T element);

        public abstract List<T> FindAll();
    }
}
