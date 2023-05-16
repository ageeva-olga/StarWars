using DAL.DTO;
using DAL.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private SWDbContext _context;
        public CharacterRepository(SWDbContext context)
        {
            _context = context;
        }

        public Character AddCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public void DeleteCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public Character GetByIdCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public List<Character> GetCharacters()
        {
            throw new NotImplementedException();
        }

        public Character UpdateCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        //public List<Character> GetCharacters()
        //{
        //    return _context.Characters.ToList();
        //}
        //public Character GetByIdCharacter(int id)
        //{
        //    var character = _context.Characters.FirstOrDefault(x => x.Id == id);
        //    if (character != null)
        //    {
        //        return character;
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException();
        //    }
        //}

        //public Character AddCharacter(Character character)
        //{
        //    _context.Characters.AddRange(character);
        //    _context.SaveChanges();
        //    return character;
        //}
        //public Character UpdateCharacter(Character character)
        //{
        //    var characterExist = GetByIdCharacter(character.Id);
        //    if (characterExist != null)
        //    {
        //        characterExist.Name = character.Name;
        //        characterExist.NameInOriginal = character.NameInOriginal;
        //        characterExist.DateOfBirth = character.DateOfBirth;
        //        characterExist.Planet = character.Planet;
        //        characterExist.Gender = character.Gender;
        //        characterExist.Race = character.Race;
        //        characterExist.Height = character.Height;
        //        characterExist.HairColor = character.HairColor;
        //        characterExist.EyeColor = character.EyeColor;
        //        characterExist.Description = character.Description;
        //        characterExist.Films.Clear();
        //        characterExist.Films.AddRange(character.Films);
        //        _context.SaveChanges();
        //    }
        //    return character;
        //}

        //public void DeleteCharacter(int id)
        //{
        //    Character character = _context.Characters.FirstOrDefault(x => x.Id == id);
        //    if (character != null)
        //    {
        //        character.Films = null;
        //        _context.Characters.Remove(character);
        //        _context.SaveChanges();
        //    }
    //}       
    }
}
