using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    public class Login
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$login_status")]
        public LoginStatus? LoginStatus { get; set; }

        [JsonProperty("$ip")]
        public string Ip { get; set; }

        [JsonProperty("$browser")]
        public Browser Browser { get; set; }

        [JsonProperty("$user_email")]
        public string UserEmail { get; set; }
    }

    public class Browser
    {
        [JsonProperty("$user_agent")]
        public string UserAgent { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LoginStatus
    {
        [EnumMember(Value = "$success")]
        Success,
        [EnumMember(Value = "$failure")]
        Failure
    }
}
