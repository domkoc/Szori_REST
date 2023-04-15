using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace Rest_FIBRPN
{
    [XmlRoot(ElementName = "movies")]
    public class MoviesDTO
    {
        [XmlElement(ElementName = "movie")]
        [JsonPropertyName("movie")]
        public List<Movie> Movies { get; set; }
    }

    [XmlRoot(ElementName = "result")]
    public class IdDTO
    {
        [XmlElement(ElementName = "id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

    [XmlRoot(ElementName = "movies")]
    public class IdsDTO
    {
        [XmlElement(ElementName = "id")]
        [JsonPropertyName("id")]
        public List<int> Ids { get; set; } = new List<int>();
    }
}
