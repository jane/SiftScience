using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Labels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AbuseType
    {
        [EnumMember(Value = "payment_abuse")]
        PaymentAbuse,
        [EnumMember(Value = "content_abuse")]
        ContentAbuse,
        [EnumMember(Value = "promotion_abuse")]
        PromotionAbuse,
        [EnumMember(Value = "account_abuse")]
        AccountAbuse,
        [EnumMember(Value = "legacy")]
        Legacy,
        [EnumMember(Value = "account_takeover")]
        AccountTakeover
    }
}