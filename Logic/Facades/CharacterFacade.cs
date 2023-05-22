using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Logic.Facades
{
    public class CharacterFacade : ICharacterFacade
    {
        private ICharacterRepository _characterRepo;
        private ILogger _logger;
        IPlanetRepository _planetRepository;
        IFilmRepository _filmRepository;
        public CharacterFacade(ICharacterRepository characterRepo, ILogger logger, 
            IPlanetRepository planetRepository, IFilmRepository filmRepository)
        {
            _characterRepo = characterRepo;
            _logger = logger;
            _planetRepository = planetRepository;
            _filmRepository = filmRepository;
        }
        public Character AddCharacter(Character character)
        {
            try
            {
                _planetRepository.PlanetInfo(character.Planet);
                _filmRepository.FilmInfo(character.Films);
                return _characterRepo.AddCharacter(character);
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            
        }

        public void DeleteCharacter(int id)
        {
            try
            {
                _characterRepo.DeleteCharacter(id);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public Character GetByIdCharacter(int id)
        {
            try
            {
                return _characterRepo.GetByIdCharacter(id);
            }
            catch(ArgumentNullException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public List<Character> GetCharacters()
        {
            return _characterRepo.GetCharacters();
        }

        public Character UpdateCharacter(Character character)
        {
            try
            {
                _planetRepository.PlanetInfo(character.Planet);
                _filmRepository.FilmInfo(character.Films);
                return _characterRepo.UpdateCharacter(character);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
