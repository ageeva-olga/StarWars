using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IPlanetRepository
    {
        public List<Planet> GetPlanets();
        public Planet GetByIdPlanet(int id);
        public Planet AddPlanet(Planet planet);
        public void PlanetInfo(Planet planet);
        public void DeletePlanet(int id);
    }
}
