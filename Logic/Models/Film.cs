using System.Text.Json.Serialization;


namespace Logic.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public List<Character>? Characters { get; set; }
    }
}
