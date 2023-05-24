using Logic.Models;

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
