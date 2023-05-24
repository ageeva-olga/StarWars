using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IPlanetFacade
    {
        public List<Planet> GetPlanets();
        public Planet AddPlanet(Planet character);
        public void DeletePlanet(int id);
    }
}
