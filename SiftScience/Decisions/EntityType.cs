using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Decisions
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EntityType
    {
        [EnumMember(Value = "user")]
        User,
        [EnumMember(Value = "order")]
        Order,
        [EnumMember(Value = "session")]
        Session
    }
}
