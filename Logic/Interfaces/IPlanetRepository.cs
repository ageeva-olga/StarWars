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
        List<Planet> GetPlanets();
        Planet AddPlanet(Planet planet);
        Planet GetPlanet(int id);
        void DeletePlanet(int id);
    }
}
