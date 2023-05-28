using Logic.Models;

namespace Logic.Interfaces
{
    public interface IFilmFacade
    {
        List<Film> GetFilms();
        Film AddFilm(Film character);
        string DeleteFilm(int id);
    }
}
