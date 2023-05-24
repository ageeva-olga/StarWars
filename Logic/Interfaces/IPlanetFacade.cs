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
        List<Planet> GetPlanets();
        Planet AddPlanet(Planet character);
        void DeletePlanet(int id);
    }
}
