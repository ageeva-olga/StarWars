using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICharacterRepository
    {
        List<Character> GetCharacters(int page, int number, FilterCharacter? filterCharacter);
        List<Character> GetCharactersByPlanet(int planetId);
        Character GetByIdCharacter(int id);
        Character AddCharacter(Character character);
        Character UpdateCharacter(Character character);
        void DeleteCharacter(int id);
    }
}
