using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    public class Content
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("$contact_phone")]
        public string ContactPhone { get; set; }

        [JsonProperty("$content_id")]
        public string ContentId { get; set; }

        [JsonProperty("$subject")]
        public string Subject { get; set; }

        [JsonProperty("$content")]
        public string Content1 { get; set; }

        [JsonProperty("$amount")]
        public long? Amount { get; set; }

        [JsonProperty("$currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("$categories")]
        public IEnumerable<string> Categories { get; set; }

        [JsonProperty("$locations")]
        public IEnumerable<Address> Locations { get; set; }

        [JsonProperty("$image_hashes")]
        public IEnumerable<string> ImageHashes { get; set; }

        [JsonProperty("$expiration_time")]
        public int? ExpirationTime { get; set; }

        [JsonProperty("$status")]
        public ContentStatus? Status { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }

        [JsonProperty("$ip")]
        public string Ip { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentStatus
    {
        [EnumMember(Value = "$draft")]
        Draft,
        [EnumMember(Value = "$pending")]
        Pending,
        [EnumMember(Value = "$active")]
        Active,
        [EnumMember(Value = "$paused")]
        Paused,
        [EnumMember(Value = "$deleted_by_user")]
        DeletedByUser,
        [EnumMember(Value = "$deleted_by_company")]
        DeletedByCompany
    }
}
