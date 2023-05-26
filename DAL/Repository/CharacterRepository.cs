using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private SWDbContext _context;
        public CharacterRepository(SWDbContext context)
        {
            _context = context;
        }

        public List<Character> GetCharacters()
        {
            var characterList = _context.Characters
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();

            return characterList;
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
    }
}
