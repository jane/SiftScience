using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    public class UpdateOrderStatus
    {
        [JsonProperty("$order_id")]
        public string OrderId { get; set; }

        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$order_status")]
        public OrderStatus? OrderStatus { get; set; }

        [JsonProperty("$reason")]
        public OrderStatusReason? Reason { get; set; }

        [JsonProperty("$source")]
        public OrderStatusSource? Source { get; set; }

        [JsonProperty("$analyst")]
        public string Analyst { get; set; }

        [JsonProperty("$webhook_id")]
        public string WebhookId { get; set; }

        [JsonProperty("$description")]
        public string Description { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {

        [EnumMember(Value = "$approved")]
        Approved,
        [EnumMember(Value = "$canceled")]
        Canceled,
        [EnumMember(Value = "$held")]
        Held,
        [EnumMember(Value = "$fulfilled")]
        Fulfilled,
        [EnumMember(Value = "$returned")]
        Returned
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatusReason
    {
        [EnumMember(Value = "$payment_risk")]
        PaymentRisk,
        [EnumMember(Value = "$abuse")]
        Abuse,
        [EnumMember(Value = "$policy")]
        Policy,
        [EnumMember(Value = "$other")]
        Other
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatusSource
    {
        [EnumMember(Value = "$automated")]
        Automated,
        [EnumMember(Value = "$manual_review")]
        ManualReview
    }
}