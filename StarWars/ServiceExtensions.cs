using DAL.Repository;
using Logic.Facades;
using Logic.Interfaces;

namespace StarWars
{
    public static class ServiceExtensions
    {
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<ICharacterFacade, CharacterFacade>();

            services.AddScoped<IPlanetRepository, PlanetRepository>();
            services.AddScoped<IPlanetFacade, PlanetFacade>();

            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmFacade, FilmFacade>();
        }
    }
}
