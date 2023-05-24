
namespace DAL.DTO
{
    public class PlanetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CharacterDTO> Characters { get; set; }
    }
}
