using Logic.Interfaces;
using Logic.Models;
using Microsoft.Extensions.Logging;

namespace Logic.Facades
{
    public class CharacterFacade : ICharacterFacade
    {
        private ICharacterRepository _characterRepo;
        private ILogger _logger;
        private IPlanetRepository _planetRepository;
        private IFilmRepository _filmRepository;
        public CharacterFacade(ICharacterRepository characterRepo, ILogger logger, 
            IPlanetRepository planetRepository, IFilmRepository filmRepository)
        {
            _characterRepo = characterRepo;
            _logger = logger;
            _planetRepository = planetRepository;
            _filmRepository = filmRepository;
        }
        public string AddCharacter(Character character)
        {
            var error = ValidateCharacter(character);
            if (String.IsNullOrEmpty(error))
            {
                _characterRepo.AddCharacter(character);
            }

            return error;

        }

        public string DeleteCharacter(int id)
        {
            try
            {
                _characterRepo.DeleteCharacter(id);

                return "";
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return ex.Message;
            }
        }

        public Character GetByIdCharacter(int id)
        {
            try
            {
                return _characterRepo.GetByIdCharacter(id);
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public List<Character> GetCharacters()
        {
            return _characterRepo.GetCharacters();
        }
        public string ValidateCharacter(Character character)
        {
            var films = _filmRepository.GetFilms(character.Films.Select(f => f.Id).ToArray());
            if (films.Count != character.Films.Count)
            {
                var message = "Film not found.";
                _logger.LogError(message);
                return message;
            }
            character.Films = films;

            var planet = _planetRepository.GetPlanet(character.PlanetId);
            if(planet == null)
            {
                var message = "Planet not found.";
                _logger.LogError(message);
                return message;
            }
            character.Planet = planet;

            return "";
        }

        public string UpdateCharacter(Character character)
        {
            try
            {
                var error = ValidateCharacter(character);
                if (String.IsNullOrEmpty(error))
                {
                    _characterRepo.UpdateCharacter(character);
                }

                return error;
            }
            catch (KeyNotFoundException ex)
            {
                var message = "Character not found.";
                _logger.LogError(message);
                return message;
            }
        }
    }
}
