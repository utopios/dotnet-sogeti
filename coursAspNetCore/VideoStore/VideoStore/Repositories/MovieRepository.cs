using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;
using VideoStore.Tools;

namespace VideoStore.Repositories
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(DataDbContext dataDbContext) : base(dataDbContext)
        {
        }

        public override bool Delete(Movie element)
        {
            _dataDbContext.Movies.Remove(element);
            return _dataDbContext.SaveChanges() > 0;
        }

        public override List<Movie> FindAll()
        {
            return _dataDbContext.Movies.ToList();
        }

        public override Movie FindById(int id)
        {
            return _dataDbContext.Movies.Include(m => m.Loan).FirstOrDefault(m => m.Id == id);
        }

        public override bool Save(Movie element)
        {
            _dataDbContext.Movies.Add(element);
            return _dataDbContext.SaveChanges() > 0;
        }

        public override List<Movie> Search(Func<Movie, bool> searchMethod)
        {
            return _dataDbContext.Movies.Where(searchMethod).ToList();
        }
    }
}
