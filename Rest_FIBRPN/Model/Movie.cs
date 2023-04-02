using System.Runtime.Serialization;

namespace Rest_FIBRPN
{
    [DataContract]
    public struct Movie
    {
        [DataMember]
        public string Id;

        [DataMember]
        public string Title;

        [DataMember]
        public int Year;

        [DataMember]
        public string Director;

        [DataMember]
        public string[] Actor;
    }
}
