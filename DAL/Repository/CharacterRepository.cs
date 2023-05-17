using AutoMapper;
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
        private readonly IMapper _mapper;
        public CharacterRepository(SWDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Character> GetCharacters()
        {
            var characterDTOList = _context.Characters.ToList();
            var characterList = new List<Character>();
            foreach(var characterDTO in characterDTOList)
            {
                characterList.Add(_mapper.Map<Character>(characterDTO));
            }
            return characterList;
        }
        public Character GetByIdCharacter(int id)
        {
            var characterDTO = _context.Characters.FirstOrDefault(x => x.Id == id);
            if (characterDTO != null)
            {
                return _mapper.Map<Character>(characterDTO);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public Character AddCharacter(Character character)
        {
            var characterDTO = _mapper.Map<CharacterDTO>(character);
            _context.Characters.AddRange(characterDTO);
            _context.SaveChanges();
            return character;
        }
        public Character UpdateCharacter(Character character)
        {
            var characterExistDTO = GetByIdCharacter(character.Id);
            if (characterExistDTO != null)
            {
                characterExistDTO.Name = character.Name;
                characterExistDTO.NameInOriginal = character.NameInOriginal;
                characterExistDTO.DateOfBirth = character.DateOfBirth;
                characterExistDTO.Planet = character.Planet;
                characterExistDTO.Gender = character.Gender;
                characterExistDTO.Race = character.Race;
                characterExistDTO.Height = character.Height;
                characterExistDTO.HairColor = character.HairColor;
                characterExistDTO.EyeColor = character.EyeColor;
                characterExistDTO.Description = character.Description;
                characterExistDTO.Films.Clear();
                characterExistDTO.Films.AddRange(character.Films);
                _context.SaveChanges();
            }
            return _mapper.Map<Character>(characterExistDTO);
        }

        public void DeleteCharacter(int id)
        {
            var characterDTO = _context.Characters.FirstOrDefault(x => x.Id == id);
            if (characterDTO != null)
            {
                characterDTO.Films = null;
                _context.Characters.Remove(characterDTO);
                _context.SaveChanges();
            }
        }
    }
}
