using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICharacterRepository
    {
        List<Character> GetCharacters();
        Character GetByIdCharacter(int id);
        Character AddCharacter(Character character);
        Character UpdateCharacter(Character character);
        void DeleteCharacter(int id);
    }
}
