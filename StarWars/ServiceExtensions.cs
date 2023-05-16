using DAL.Interfaces;
using DAL.Repository;

namespace StarWars
{
    public static class ServiceExtensions
    {
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<ICharacterRepository, CharacterRepository>();
        }
    }
}
