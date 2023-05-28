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

        [HttpPut]
        public Planet AddPlanet(Planet planet)
        {
            var characterModel = _planetFacade.AddPlanet(planet);

            return characterModel;
        }

        [HttpDelete]
        public IActionResult DeletePlanet(int id)
        {
            var error = _planetFacade.DeletePlanet(id);

            if (String.IsNullOrEmpty(error))
            {
                return Ok();
            }
            return BadRequest(error);
        }
    }
}
