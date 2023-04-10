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

    [DataContract(Name = "result")]
    public class IdDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        public IdDTO(int id)
        {
            Id = id;
        }
    }

    [CollectionDataContract(Name = "id")]
    public class IdsList : List<int> { }

    [DataContract(Name = "movies")]
    public class IdsDTO
    {
        [DataMember(Name = "id")]
        public IdsList Id { get; set; } = new IdsList();

        public IdsDTO(int[] ids)
        {
            Id.AddRange(ids);
        }
    }
}
