using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICharacterFacade
    {
        List<Character> GetCharacters(int page, int number, FilterCharacter? filterCharacter);
        List<Character> GetCharactersByPlanet(int planetId, int skip, int take);
        Character GetByIdCharacter(int id);
        string AddCharacter(Character character);
        string UpdateCharacter(Character character);
        string DeleteCharacter(int id);
    }
}
