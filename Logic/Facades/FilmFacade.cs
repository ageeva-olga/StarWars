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

        public void DeleteFilm(int id)
        {
            try
            {
                _filmRepository.DeleteFilm(id);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public List<Film> GetFilms()
        {
            return _filmRepository.GetFilms();
        }
    }
}
