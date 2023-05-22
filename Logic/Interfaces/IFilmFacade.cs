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
        public List<Film> GetFilms();
        public Film GetByIdFilm(int id);
        public Film AddFilm(Film character);
        public void DeleteFilm(int id);
    }
}
