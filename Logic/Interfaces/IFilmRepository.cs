using Logic.Models;

namespace Logic.Interfaces
{
    public interface IFilmRepository
    {
        
        List<Film> GetFilms();      
        
        Film AddFilm(Film film);
        
        List<Film> GetFilms(int[] ids);
        
        void FilmInfo(List<Film> film);
        
        void DeleteFilm(int id);
    }
}
