using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SWDbContext: DbContext
    {
        public DbSet<CharacterDTO> Characters { get; set; }
        public DbSet<PlanetDTO> Planets { get; set; }
        public DbSet<FilmDTO> Films { get; set; }

        //private string _conectionString = "Data Source=usersdata.db";

        public SWDbContext(DbContextOptions<SWDbContext> options) : base(options)
        {
        }
        //public SWDbContext()
        //{
        //    Database.EnsureCreated();
        //}
        //public SWDbContext(string connectionString)
        //{
        //    _conectionString = connectionString;
        //    Database.EnsureCreated();
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(_conectionString);
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
