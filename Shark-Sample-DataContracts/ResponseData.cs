using System.Runtime.Serialization;

namespace SharkSample.DataContracts
{
    [DataContract]
    public class ResponseData<T>
    {
        [DataMember]
        public CommunicationResults Result { get; set; }
        
        [DataMember]
        public T Data { get; set; }

        public ResponseData() : base()
        {

        }

        public ResponseData(CommunicationResults result, T data)
        {
            Result = result;
            Data = data;
        }

        public ResponseData(CommunicationResults result)
        {
            Result = result;
            Data = default(T);
        }
    }
}
