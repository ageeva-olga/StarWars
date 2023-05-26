using Logic.Facades;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject1
{
    public class UnitTest1
    {
        Planet planet1;
        Film film1;

        [OneTimeSetUp]
        public void NewDirAndFiles()
        {
            planet1 = new Planet() { Id = 1, Name = "Tatooine" };
            film1 = new Film() { Id = 1, Name = "A New Hope" };
        }
        [Test]
        public void TestMethod1()
        {
            var characterRepo = new Mock<ICharacterRepository>();
            var loggerMock = new Mock<ILogger>();
            var planetRepo = new Mock<IPlanetRepository>();
            var filmRepo = new Mock<IFilmRepository>();
            var character = new Character()
            {
                Id = 1,
                Name = "A",
                NameInOriginal = "Aa",
                DateOfBirth = "11",
                PlanetId = 1,
                Gender = Gender.Male,
                Race = "st",
                Height = "",
                HairColor = "",
                EyeColor = "",
                Description = "",
                Films = new List<Film> { new Film() { Id = 2, Name = "A New Film" } }
            };

            filmRepo.Setup(x => x.GetFilms(new int[] { })).Returns(new List<Film>() { });

            planetRepo.Setup(x => x.GetPlanet(1)).Returns(planet1);

            var charFacade = new CharacterFacade(characterRepo.Object, loggerMock.Object, planetRepo.Object, filmRepo.Object);
            var result = charFacade.ValidateCharacter(character);

            Assert.AreEqual("Film not found.", result);
        }
    }
}