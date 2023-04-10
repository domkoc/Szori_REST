using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

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

    [DataContract]
    public class Movie
    {
        private int Id { get; set; } = IdGenerator.GetNextId();

        [DataMember]
        public string Title { get; set; } = "";

        [DataMember]
        public int Year { get; set; } = 0;

        [DataMember]
        public string Director { get; set; } = "";

        [DataMember]
        public string[] Actor { get; set; } = Array.Empty<string>();

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
