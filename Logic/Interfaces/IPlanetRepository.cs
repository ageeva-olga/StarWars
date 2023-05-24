using Logic.Models;

namespace Logic.Interfaces
{
    public interface IPlanetRepository
    {
        List<Planet> GetPlanets();
        Planet AddPlanet(Planet planet);
        Planet GetPlanet(int id);
        void DeletePlanet(int id);
    }
}
