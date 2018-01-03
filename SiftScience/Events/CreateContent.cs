using Newtonsoft.Json;

namespace SiftScience.Events
{
    public class CreateContent
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("$contact_phone")]
        public string ContactPhone { get; set; }

        [JsonProperty("$subject")]
        public string Subject { get; set; }        
    }
}
