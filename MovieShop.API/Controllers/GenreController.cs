using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Services;
using MovieShop.Entities;


namespace MovieShop.API.Controllers
{   [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        [Route("")]
        public async Task <IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenres();
            if (genres.Any())
            {
                return Ok(genres);
            }
            else
            {
                return NotFound();
                    
            }
        }

        [HttpGet]
        [Route("{id}/movies")]
        public async Task<IActionResult> GetMovieByGenre(int id)
        {
            var movies = await _genreService.GetMovieByGenre(id);
            return Ok(movies);
        }
    }
}