using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    public class Account
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$user_email")]
        public string UserEmail { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$name")]
        public string Name { get; set; }

        [JsonProperty("$phone")]
        public string Phone { get; set; }

        [JsonProperty("$referrer_user_id")]
        public string ReferrerUserId { get; set; }

        [JsonProperty("$payment_methods")]
        public List<PaymentMethod> PaymentMethods { get; set; }

        [JsonProperty("$billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("$shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("$social_sign_on_type")]
        public SocialSignOn? SocialSignOn { get; set; }

        [JsonProperty("$changed_password")]
        public bool? ChangedPassword { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }

        [JsonProperty("$ip")]
        public string Ip { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SocialSignOn
    {
        [EnumMember(Value = "$facebook")]
        Facebook,
        [EnumMember(Value = "$google")]
        Google,
        [EnumMember(Value = "$yahoo")]
        Yahoo,
        [EnumMember(Value = "$twitter")]
        Twitter,
        [EnumMember(Value = "$other")]
        Other
    }
}