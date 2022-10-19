using Microsoft.AspNetCore.Mvc;
using VideoStore.Models;
using VideoStore.Repositories;

namespace AspNetVideoStore.Controllers
{
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private MovieRepository _movieRepository;

        public MovieController(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("")]
        public List<Movie> DisplayMovies()
        {
            return _movieRepository.FindAll();
        }

        [HttpGet("display/{id}")]
        public Movie DisplayMovie(int id)
        {
            return _movieRepository.FindById(id);
        }

        [HttpGet("search/{search}")]
        public List<Movie> DisplayMovies(string search)
        {
            return _movieRepository.Search((m) => m.Name.Contains(search) || m.Director.Contains(search));
        }

        [HttpPost("add")]
        public Movie Add([FromBody] Movie movie)
        {
            if(_movieRepository.Save(movie))
            {
                return movie;
            }
            return null;
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteMovie(int id)
        {
            Movie movie  = _movieRepository.FindById(id);
            if(movie != null)
            {
                return _movieRepository.Delete(movie);
            }
            return false;
        }

        [HttpPut("update/{id}")]
        public bool Update(int id, [FromBody] Movie newmovie)
        {
            Movie movie = _movieRepository.FindById(id);
            if (movie != null)
            {
                movie.Name = newmovie.Name;
                movie.Director = newmovie.Director;
                movie.Description = newmovie.Description;
                movie.Score = newmovie.Score;
                movie.Price = newmovie.Price;
                return _movieRepository.Update();
            }
            return false;
        }
    }
}
