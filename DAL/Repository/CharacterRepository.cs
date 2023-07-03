using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private SWDbContext _context;
        public CharacterRepository(SWDbContext context)
        {
            _context = context;
        }

        public List<Character> GetCharacters(int page, int number, FilterCharacter filterCharacter)
        {
            Expression<Func<Character, bool>> expression = x => true;
            if(!String.IsNullOrEmpty(filterCharacter.Name))
            {
                var parameterExpression = Expression.Parameter(Type.GetType("Logic.Models.Character"));
                var constant = Expression.Constant(filterCharacter.Name);
                var property = Expression.Property(parameterExpression, "Name");
                var expressionName = Expression.Equal(property, constant);
                var expressionAnd = Expression.And(expression, expressionName);
                expression = Expression.Lambda<Func<Character, bool>>(expressionAnd);
            }

            if (!String.IsNullOrEmpty(filterCharacter.PlanetName))
            {
                var parameterExpression = Expression.Parameter(Type.GetType("Logic.Models.Character"));
                var constant = Expression.Constant(filterCharacter.PlanetName);
                var property = Expression.Property(parameterExpression, "Planet.Name");
                var expressionName = Expression.Equal(property, constant);
                var expressionAnd = Expression.And(expression, expressionName);
                expression = Expression.Lambda<Func<Character, bool>>(expressionAnd);
            }


            var filter = Expression.Lambda<Func<Character, bool>>(expression);

            return _context.Characters
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .Where(filter.Compile())//(x => x.Planet.Name == filterCharacter.PlanetName)
                .ToList();

            if (!String.IsNullOrEmpty(filterCharacter.PlanetName) &&
                String.IsNullOrEmpty(filterCharacter.Name)&&
                String.IsNullOrEmpty(filterCharacter.FilmName))
            {
                return _context.Characters
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .Where(filter.Compile())//(x => x.Planet.Name == filterCharacter.PlanetName)
                .ToList();
            }

            if (String.IsNullOrEmpty(filterCharacter.PlanetName) &&
                !String.IsNullOrEmpty(filterCharacter.Name) &&
                String.IsNullOrEmpty(filterCharacter.FilmName))
            {
                return _context.Characters
                .Where(x => x.Name == filterCharacter.Name)
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();
            }

            if (String.IsNullOrEmpty(filterCharacter.PlanetName) &&
                String.IsNullOrEmpty(filterCharacter.Name) &&
                !String.IsNullOrEmpty(filterCharacter.FilmName))
            {
                return _context.Characters
                .Where(x => x.Films.FirstOrDefault(film => film.Name == filterCharacter.FilmName).Name == filterCharacter.FilmName)
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();
            }

            if (!String.IsNullOrEmpty(filterCharacter.PlanetName) &&
                !String.IsNullOrEmpty(filterCharacter.Name) &&
                String.IsNullOrEmpty(filterCharacter.FilmName))
            {
                return _context.Characters
                .Where(x => x.Planet.Name == filterCharacter.PlanetName && x.Name == filterCharacter.Name)
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();
            }

            if (!String.IsNullOrEmpty(filterCharacter.PlanetName) &&
                !String.IsNullOrEmpty(filterCharacter.Name) &&
                !String.IsNullOrEmpty(filterCharacter.FilmName))
            {
                return _context.Characters
                .Where(x => x.Planet.Name == filterCharacter.PlanetName 
                && x.Name == filterCharacter.Name
                && x.Films.Any(film => film.Name == filterCharacter.FilmName))
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();
            }

            if (!String.IsNullOrEmpty(filterCharacter.PlanetName) &&
                String.IsNullOrEmpty(filterCharacter.Name) &&
                !String.IsNullOrEmpty(filterCharacter.FilmName))
            {
                return _context.Characters
                .Where(x => x.Planet.Name == filterCharacter.PlanetName
                && x.Films.FirstOrDefault(film => film.Name == filterCharacter.FilmName).Name == filterCharacter.FilmName)
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();
            }
            if (String.IsNullOrEmpty(filterCharacter.PlanetName) &&
                !String.IsNullOrEmpty(filterCharacter.Name) &&
                !String.IsNullOrEmpty(filterCharacter.FilmName))
            {
                return _context.Characters
                .Where(x => x.Name == filterCharacter.Name
                && x.Films.FirstOrDefault(film => film.Name == filterCharacter.FilmName).Name == filterCharacter.FilmName)
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();
            }


            return _context.Characters
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .Skip(page).Take(number)
                .ToList();
        }
        public Character GetByIdCharacter(int id)
        {
            var character = _context.Characters
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .FirstOrDefault(x => x.Id == id);

            if (character == null)
            {
                throw new KeyNotFoundException();
            }

            return character;
        }

        public Character AddCharacter(Character character)
        {
            _context.Characters.AddRange(character);
            _context.SaveChanges();
            return character;
        }
        public Character UpdateCharacter(Character character)
        {
            var characterExist = GetByIdCharacter(character.Id);

            characterExist.Name = character.Name;
            characterExist.NameInOriginal = character.NameInOriginal;
            characterExist.DateOfBirth = character.DateOfBirth;
            characterExist.Planet = character.Planet;
            characterExist.Gender = character.Gender;
            characterExist.Race = character.Race;
            characterExist.Height = character.Height;
            characterExist.HairColor = character.HairColor;
            characterExist.EyeColor = character.EyeColor;
            characterExist.Description = character.Description;
            characterExist.Films.Clear();
            characterExist.Films.AddRange(character.Films);
            _context.SaveChanges();

            return characterExist;
        }

        public void DeleteCharacter(int id)
        {
            var character = _context.Characters.FirstOrDefault(x => x.Id == id);

            if (character == null)
            {
                throw new KeyNotFoundException();
            }

            character.Films = null;
            _context.Characters.Remove(character);
            _context.SaveChanges();
        }

        public List<Character> GetCharactersByPlanet(int planetId)
        {
            var characterList = _context.Characters
                .Where(x => x.PlanetId == planetId)
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();

            return characterList;
        }
    }
}
