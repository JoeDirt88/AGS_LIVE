using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AGS.ServerAPI.DAL_Models
{
    [DataContract]
    public class VadModel
    {
        // TestData
        [DataMember (Name = "params")]
        public List<string> ParametersVad { get; set; }
    }
    [DataContract]
    public class MetModel
    {
        // TestData
        [DataMember (Name = "age")]
        public string Age { get; set; }

        [DataMember(Name = "waist")]
        public string Waist { get; set; }

        [DataMember(Name = "syst")]
        public string Systolic { get; set; }
    }
}