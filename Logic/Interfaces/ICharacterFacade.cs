﻿using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICharacterFacade
    {
        public List<Character> GetCharacters();
        public Character GetByIdCharacter(int id);
        public Character AddCharacter(Character character);
        public Character UpdateCharacter(Character character);
        public void DeleteCharacter(int id);
    }
}
