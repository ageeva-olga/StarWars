using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private SWDbContext _context;
        public FilmRepository(SWDbContext context)
        {
            _context = context;
        }

        public Film AddFilm(Film film)
        {
            _context.Films.AddRange(film);
            _context.SaveChanges();
            return film;
        }
        public void DeleteFilm(int id)
        {
            var film = _context.Films.FirstOrDefault(x => x.Id == id);
            if (film != null)
            {
                film.Characters = null;
                _context.Films.Remove(film);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public List<Film> GetFilms()
        {
            var filmList = _context.Films
                .Include(film => film.Characters)
                .ToList();
            var filmResultList = new List<Film>();
            foreach (var film in filmList)
            {
                filmResultList.Add(film);
            }
            return filmResultList;
        }

        public List<Film> GetFilms(int[] ids)
        {
            var filmList = _context.Films.Where(f => ids.Any(id => id == f.Id))
                .ToList();
            return filmList;
        }

        public void FilmInfo(List<Film> films)
        {
            var filmsList = new List<Film>() { };
            foreach(var film in films)
            {
                filmsList.Add(_context.Films.FirstOrDefault(z => z.Id == film.Id));
            }           
            if (filmsList.Count == 0)
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}
