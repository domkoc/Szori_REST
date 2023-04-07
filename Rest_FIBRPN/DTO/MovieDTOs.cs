using System.Runtime.Serialization;

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

    [DataContract]
    public struct AddMovieDTO
    {

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Director { get; set; }

        public Movie asMovie()
        {
            return new Movie()
            {
                Id = IdGenerator.GetNextId(),
                Title = Title,
                Year = Year,
                Director = Director,
                Actor = new string[0]
            };
        }
    }

    [DataContract]
    public class GetMoviesDTO
    {
        [DataMember]
        public Movie[] movie { get; set; }
        public GetMoviesDTO(Movie[] movies) 
        { 
            movie = movies;
        }
    }
}
