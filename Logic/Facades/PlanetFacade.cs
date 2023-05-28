using Logic.Interfaces;
using Logic.Models;
using Microsoft.Extensions.Logging;

namespace Logic.Facades
{
    public class PlanetFacade : IPlanetFacade
    {
        private IPlanetRepository _planetRepository;
        private ILogger _logger;
        public PlanetFacade(IPlanetRepository planetRepository, ILogger logger)
        {
            _planetRepository = planetRepository;
            _logger = logger;
        }
        public Planet AddPlanet(Planet planet)
        {
            return _planetRepository.AddPlanet(planet);
        }

        public string DeletePlanet(int id)
        {
            try
            {
                _planetRepository.DeletePlanet(id);
                return "";
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return ex.Message;
            }
        }

        public List<Planet> GetPlanets()
        {
            return _planetRepository.GetPlanets();
        }
    }
}
