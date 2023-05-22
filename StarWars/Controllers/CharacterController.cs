using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController: Controller
    {
        private ICharacterFacade _characterFacade;
        public CharacterController(ICharacterFacade characterFacade)
        {
            _characterFacade = characterFacade;
        }
        [HttpGet("getList")]
        public List<Character> GetCharacters()
        {
            var model = _characterFacade.GetCharacters();
            return model;
        }

        [HttpGet("getById")]
        public Character GetByIdCharacters(int id)
        {
            var characterModel = _characterFacade.GetByIdCharacter(id);
            return characterModel;
        }
        [HttpPut]
        public Character AddCharacter(Character character)
        {
            var characterModel = _characterFacade.AddCharacter(character);

            return characterModel;
        }

        [HttpPost]
        public Character UpdateCharacter(Character character)
        {
            var characterModel = _characterFacade.UpdateCharacter(character);

            return characterModel;
        }

        [HttpDelete]
        public IActionResult DeleteCharacter(int id)
        {
            _characterFacade.DeleteCharacter(id);
            return Ok();
        }
    }
}
