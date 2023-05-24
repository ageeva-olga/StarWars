using Logic.Models;

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
