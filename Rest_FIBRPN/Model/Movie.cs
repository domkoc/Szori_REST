using System.Runtime.Serialization;

namespace Rest_FIBRPN
{
    [DataContract] // FIXME: Hogyan kapcsoljuk be a szerializálást
    public struct Movie
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Director { get; set; }

        [DataMember]
        public string[] Actor { get; set; }
    }
}
