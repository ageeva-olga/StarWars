using AutoMapper;
using DAL.DTO;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Character> GetCharacters()
        {
            var characterList = _context.Characters
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .ToList();
            var characterResultList = new List<Character>();
            foreach(var character in characterList)
            {
                characterResultList.Add(character);
            }
            return characterResultList;
        }
        public Character GetByIdCharacter(int id)
        {
            var character = _context.Characters
                .Include(character => character.Planet)
                .Include(character => character.Films)
                .FirstOrDefault(x => x.Id == id);
            if (character != null)
            {
                return character;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public Character AddCharacter(Character character)
        {
            //character.Films = character.Films.Select(x => _context.Films.First(z => z.Id == x.Id)).ToList();
            //character.Planet = _context.Planets.First(p => p.Id == character.PlanetId);
            _context.Characters.AddRange(character);
            _context.SaveChanges();
            return character;
        }
        public Character UpdateCharacter(Character character)
        {
            var characterExist = GetByIdCharacter(character.Id);
            if (characterExist != null)
            {
                characterExist.Name = character.Name;
                characterExist.NameInOriginal = character.NameInOriginal;
                characterExist.DateOfBirth = character.DateOfBirth;
                //characterExist.Planet = _context.Planets.First(p => p.Id == character.PlanetId);
                characterExist.Planet = character.Planet;
                characterExist.Gender = character.Gender;
                characterExist.Race = character.Race;
                characterExist.Height = character.Height;
                characterExist.HairColor = character.HairColor;
                characterExist.EyeColor = character.EyeColor;
                characterExist.Description = character.Description;
                characterExist.Films.Clear();
                characterExist.Films.AddRange(character.Films);
                //characterExist.Films.AddRange(character.Films.Select(x => _context.Films.First(z => z.Id == x.Id)).ToList());
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
            return characterExist;
        }

        public void DeleteCharacter(int id)
        {
            var character = _context.Characters.FirstOrDefault(x => x.Id == id);
            if (character != null)
            {
                character.Films = null;
                _context.Characters.Remove(character);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
