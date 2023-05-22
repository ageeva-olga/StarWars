using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.ModelDTO;
using DAL.ModelMapping;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SWDbContext: DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Film> Films { get; set; }

        public SWDbContext(DbContextOptions<SWDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new CharacterConfiguration().Configure(builder.Entity<Character>());
            new PlanetConfiguration().Configure(builder.Entity<Planet>());
            new FilmConfiguration().Configure(builder.Entity<Film>());

            var film1 = new Film() { Id = 1, Name = "A New Hope", Characters = new List<Character>() { } };
            var film2 = new Film() { Id = 2, Name = "The Empire Strikes Back", Characters = new List<Character>() { } };
            var film3 = new Film() { Id = 3, Name = "The PHantom Menace", Characters = new List<Character>() { } };
            builder.Entity<Film>().HasData(film1, film2, film3);

            var planet1 = new Planet() { Id = 1, Name = "Alderaan", Characters = new List<Character>() { } };
            var planet2 = new Planet() { Id = 2, Name = "Onderon", Characters = new List<Character>() { } };
            var planet3 = new Planet() { Id = 3, Name = "Tatooine", Characters = new List<Character>() { } };
            builder.Entity<Planet>().HasData(planet1, planet2, planet3);
        }
    }
}
