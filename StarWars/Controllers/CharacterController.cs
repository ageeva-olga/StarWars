using DAL.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController: Controller
    {
        private ICharacterRepository _characterRepo;
        public CharacterController(ICharacterRepository characterRepo)
        {
            _characterRepo = characterRepo;
        }
        [HttpGet]
        public List<Character> GetCharacters()
        {
            var model = _characterRepo.GetCharacters();
            return model;
        }
        [HttpPut]
        public Character AddCharacter(Character character)
        {
            var characterModel = _characterRepo.AddCharacter(character);

            return characterModel;
        }

        [HttpPost]
        public Character UpdateCharacter(Character character)
        {
            var characterModel = _characterRepo.UpdateCharacter(character);

            return characterModel;
        }

        [HttpDelete]
        public IActionResult DeleteCharacter(int id)
        {
            _characterRepo.DeleteCharacter(id);
            return Ok();
        }
    }
}
