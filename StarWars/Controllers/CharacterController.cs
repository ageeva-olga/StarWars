﻿using Logic.Interfaces;
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
        public IActionResult AddCharacter(Character character)
        {
            var error = _characterFacade.AddCharacter(character);

            if (String.IsNullOrEmpty(error))
            {
                return Ok();
            }
            return BadRequest(error);
        }

        [HttpPost]
        public IActionResult UpdateCharacter(Character character)
        {
            var error = _characterFacade.UpdateCharacter(character);

            if(String.IsNullOrEmpty(error))
            {
                return Ok();
            }
            return BadRequest(error);
        }

        [HttpDelete]
        public IActionResult DeleteCharacter(int id)
        {
            _characterFacade.DeleteCharacter(id);
            return Ok();
        }
    }
}
