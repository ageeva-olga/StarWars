using Logic.Models;

namespace Logic.Interfaces
{
    public interface IPlanetFacade
    {
        List<Planet> GetPlanets();
        Planet AddPlanet(Planet character);
        string DeletePlanet(int id);
    }
}
