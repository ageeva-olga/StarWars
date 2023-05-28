using Logic.Interfaces;
using Logic.Models;
using Microsoft.Extensions.Logging;

namespace Logic.Facades
{
    public class FilmFacade : IFilmFacade
    {
        private IFilmRepository _filmRepository;
        private ILogger _logger;
        public FilmFacade(IFilmRepository filmRepository, ILogger logger)
        {
            _filmRepository = filmRepository;
            _logger = logger;
        }
        public Film AddFilm(Film film)
        {
            return _filmRepository.AddFilm(film);
        }

        public string DeleteFilm(int id)
        {
            try
            {
                _filmRepository.DeleteFilm(id);
                return "";
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return ex.Message;
            }
        }

        public List<Film> GetFilms()
        {
            return _filmRepository.GetFilms();
        }
    }
}
