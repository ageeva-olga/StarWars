using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICharacterFacade
    {
        List<Character> GetCharacters();
        Character GetByIdCharacter(int id);
        string AddCharacter(Character character);
        string UpdateCharacter(Character character);
        void DeleteCharacter(int id);
    }
}
