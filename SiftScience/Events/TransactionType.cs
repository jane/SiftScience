using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionType
    {
        [EnumMember(Value = "$sale")]
        Sale,
        [EnumMember(Value = "$authorize")]
        Authorize,
        [EnumMember(Value = "$capture")]
        Capture,
        [EnumMember(Value = "$void")]
        Void,
        [EnumMember(Value = "$refund")]
        Refund,
        [EnumMember(Value = "$deposit")]
        Deposit,
        [EnumMember(Value = "$withdrawal")]
        Withdrawal,
        [EnumMember(Value = "$transfer")]
        Transfer
    }
}