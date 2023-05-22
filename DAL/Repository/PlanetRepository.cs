using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PlanetRepository : IPlanetRepository
    {
        private SWDbContext _context;
        public PlanetRepository(SWDbContext context)
        {
            _context = context;
        }
        public Planet AddPlanet(Planet planet)
        {
            _context.Planets.AddRange(planet);
            _context.SaveChanges();
            return planet;
        }

        public void DeletePlanet(int id)
        {
            var planet = _context.Planets.FirstOrDefault(x => x.Id == id);
            if (planet != null)
            {
                planet.Characters = null;
                _context.Planets.Remove(planet);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public Planet GetByIdPlanet(int id)
        {
            var planet = _context.Planets
                .Include(planet => planet.Characters)
                .FirstOrDefault(x => x.Id == id);
            if (planet != null)
            {
                return planet;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public List<Planet> GetPlanets()
        {
            var planetList = _context.Planets
                .Include(planet => planet.Characters)
                .ToList();
            var planetResultList = new List<Planet>();
            foreach (var planet in planetList)
            {
                planetResultList.Add(planet);
            }
            return planetResultList;
        }

        public void PlanetInfo(Planet planet)
        {
            var planetFirst = _context.Planets.FirstOrDefault(p => p.Id == planet.Id);
            if (planet == null)
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}
