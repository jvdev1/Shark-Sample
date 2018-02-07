using System.Runtime.Serialization;

namespace SharkSample.DataContracts
{
    [DataContract]
    public class SampleDataForRequest
    {
        [DataMember]
        public SampleDataForNesting[] Nested { get; set; }
    }
}