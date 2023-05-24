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
        public Planet AddPlanet(Planet planet);
        public Planet GetPlanet(int id);
        public void DeletePlanet(int id);
    }
}
