using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Labels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AbuseType
    {
        [EnumMember(Value = "payment_abuse")]
        Payment,
        [EnumMember(Value = "content_abuse")]
        Content,
        [EnumMember(Value = "promotion_abuse")]
        Promotion,
        [EnumMember(Value = "account_abuse")]
        Account
    }
}