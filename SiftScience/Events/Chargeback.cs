using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    public class Chargeback
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$order_id")]
        public string OrderId { get; set; }

        [JsonProperty("$transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("$chargeback_state")]
        public ChargebackState ChargebackState { get; set; }

        [JsonProperty("$chargeback_reason")]
        public ChargebackReason ChargebackReason { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChargebackState
    {
        [EnumMember(Value = "$received")]
        Received,
        [EnumMember(Value = "$accepted")]
        Accepted,
        [EnumMember(Value = "$disputed")]
        Disputed,
        [EnumMember(Value = "$won")]
        Won,
        [EnumMember(Value = "$lost")]
        Lost
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChargebackReason
    {
        [EnumMember(Value = "$fraud")]
        Fraud,
        [EnumMember(Value = "$duplicate")]
        Duplicate,
        [EnumMember(Value = "$product_not_received")]
        Product_Not_Received,
        [EnumMember(Value = "$product_unacceptable")]
        Product_Unacceptable,
        [EnumMember(Value = "$other")]
        Other
    }
}
