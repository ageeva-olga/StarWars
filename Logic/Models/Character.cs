
namespace Logic.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameInOriginal { get; set; }
        public string DateOfBirth { get; set; }
        public int PlanetId { get; set; }
        public Planet? Planet { get; set; }
        public Gender Gender { get; set; }
        public string Race { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Description { get; set; }
        public List<Film> Films { get; set; }
    }
}
