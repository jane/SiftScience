using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Decisions
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        [EnumMember(Value = "accept")]
        Accept,
        [EnumMember(Value = "watch")]
        Watch,
        [EnumMember(Value = "block")]
        Block
    }
}