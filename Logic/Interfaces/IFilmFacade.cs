using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IFilmFacade
    {
        List<Film> GetFilms();
        Film AddFilm(Film character);
        void DeleteFilm(int id);
    }
}
