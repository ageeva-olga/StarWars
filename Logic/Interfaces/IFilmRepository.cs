using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
