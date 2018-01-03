using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        [EnumMember(Value = "$success")]
        Success,
        [EnumMember(Value = "$failure")]
        Failure,
        [EnumMember(Value = "$pending")]
        Pending
    }
}