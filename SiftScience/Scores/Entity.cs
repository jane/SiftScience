using Newtonsoft.Json;

namespace SiftScience.Scores
{
    public class Entity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
