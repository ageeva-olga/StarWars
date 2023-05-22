using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private IFilmFacade _filmFacade;
        public FilmController(IFilmFacade filmFacade)
        {
            _filmFacade = filmFacade;
        }
        [HttpGet("getList")]
        public List<Film> GetCharacters()
        {
            var model = _filmFacade.GetFilms();
            return model;
        }

        [HttpGet("getById")]
        public Film GetByIdCharacters(int id)
        {
            var filmModel = _filmFacade.GetByIdFilm(id);
            return filmModel;
        }
        [HttpPut]
        public Film AddCharacter(Film character)
        {
            var filmModel = _filmFacade.AddFilm(character);

            return filmModel;
        }

        [HttpDelete]
        public IActionResult DeleteCharacter(int id)
        {
            _filmFacade.DeleteFilm(id);
            return Ok();
        }
    }
}
