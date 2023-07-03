using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    [BindProperties]
    public class FilterCharacter
    {
        public string? Name { get; set; }
        public string? PlanetName { get; set; }
        public string? FilmName { get; set; }
    }
}
