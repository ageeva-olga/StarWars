using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : Controller
    {
        private IPlanetFacade _planetFacade;
        public PlanetController(IPlanetFacade planetFacade)
        {
            _planetFacade = planetFacade;
        }
        [HttpGet("getList")]
        public List<Planet> GetPlanets()
        {
            var model = _planetFacade.GetPlanets();
            return model;
        }

        [HttpGet("getById")]
        public Planet GetByIdPlanet(int id)
        {
            var characterModel = _planetFacade.GetByIdPlanet(id);
            return characterModel;
        }
        [HttpPut]
        public Planet AddPlanet(Planet planet)
        {
            var characterModel = _planetFacade.AddPlanet(planet);

            return characterModel;
        }

        [HttpDelete]
        public IActionResult DeletePlanet(int id)
        {
            _planetFacade.DeletePlanet(id);
            return Ok();
        }
    }
}
