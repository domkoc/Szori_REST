using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Rest_FIBRPN
{
    [XmlRoot("movies")] // FIXME: Root element xml-ben ott van json-ben is
    public class MoviesDTO
    {
        [XmlElement("movie")]
        public List<Movie> Movies { get; set; }
    }

    [XmlRoot("movies")]
    public class IdsDTO
    {
        [XmlElement("id")]
        public List<int> Ids { get; set; }
    }
}
