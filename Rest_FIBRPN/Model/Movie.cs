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
    public class Movie
    {
        [DataMember]
        public int Id { get; set; } = IdGenerator.GetNextId();

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Director { get; set; }

        [DataMember]
        public string[] Actor { get; set; } = new string[0];
    }
}
