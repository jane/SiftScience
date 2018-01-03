using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Scores
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum State
    {
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "finished")]
        Finished,
        [EnumMember(Value = "failed")]
        Failed
    }
}
