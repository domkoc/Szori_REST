using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace Rest_FIBRPN
{
    static class IdGenerator
    {
        private static int LastId = -1;
        public static int GetNextId()
        {
            LastId++;
            return LastId;
        }
    }

    [XmlRoot("movies")]
    public class MoviesList : List<Movie> { }

    [XmlRoot(ElementName = "movie")]
    public class Movie
    {
        private int Id { get; set; } = IdGenerator.GetNextId();

        [XmlElement(ElementName = "title")]
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [XmlElement(ElementName = "year")]
        [JsonPropertyName("year")]
        public int Year { get; set; } = 0;

        [XmlElement(ElementName = "director")]
        [JsonPropertyName("director")]
        public string Director { get; set; } = "";

        [XmlElement(ElementName = "actor")]
        [JsonPropertyName("actor")]
        public List<string> Actor { get; set; } = new List<string>();

        public int getId()
        {
            return Id;
        }

        public void setId(int id)
        {
            Id = id;
        }
    }
}
