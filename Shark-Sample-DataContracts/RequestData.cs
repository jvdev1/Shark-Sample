using System.Runtime.Serialization;

namespace SharkSample.DataContracts
{
    [DataContract]
    public class RequestData<T>
    {
        [DataMember]
        public string CredentialID { get; set; }

        [DataMember]
        public CredentialTypes CredentialType { get; set; }
        
        [DataMember]
        public T Data { get; set; }

        public RequestData() : base()
        {

        }

        public RequestData(string credential, CredentialTypes type, T data)
        {
            CredentialID = credential;
            CredentialType = type;
            Data = data;
        }
    }
}
