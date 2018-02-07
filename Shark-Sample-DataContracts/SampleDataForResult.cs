using System.Runtime.Serialization;

namespace SharkSample.DataContracts
{
    [DataContract]
    public class SampleDataForResult
    {
        [DataMember]
        public SampleDataForNesting[] Nested { get; set; }
    }
}