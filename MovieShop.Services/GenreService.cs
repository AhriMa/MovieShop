using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Entities;
using MovieShop.Data;
using System.Threading.Tasks;
using System.Linq;
namespace MovieShop.Services
{
    public class GenreService: IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllAsync();
            return genres.OrderBy(g => g.Name);
        }

        public async Task<IEnumerable<Movie>> GetMovieByGenre(int genreid)
        {
            var movies = await _genreRepository.GetMovieByGenre(genreid);
            return movies;
        }
    }
}
