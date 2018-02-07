using System.Runtime.Serialization;

namespace SharkSample.DataContracts
{
    [DataContract]
    public class SampleDataForNesting
    {
        [DataMember]
        public string[] TrainingProgramGroupNames { get; set; }

        [DataMember]
        public string[] TrainingProgramNames { get; set; }
    }
}